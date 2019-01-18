using System;
using System.Text;
using System.Threading;
using PCSC;
using EnglishClassManager.Utility.Database;
using EnglishCalssManager.Rollcall.StudentRollcall;
using AOISystem.Utility.Logging;

namespace SmartCardSystem
{
    public static class SmartCardReader
    {
        //public DatabaseConnection;
        static void CheckErr(SCardError err)
        {
            if (err != SCardError.Success)
                throw new PCSCException(err,
                    SCardHelper.StringifyError(err));
        }
        public static string getCount(string date, string StudentID)
        {
            //DatabaseManager.Initialize();
            try
            {
                string CommandStr = string.Format("select Max( EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.RollcallCount) "
                    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
                    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID = '{1}'", date, StudentID);
                string _getCount = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
                return _getCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }

        }


        // 更換更新flag
        public static void changeUpdate(string date, string StudentID, string _getChange)
        {
            string CommandStr = string.Format(
            "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
            + " Set IsUpdate={1} "
            //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
            //+ " and "
            + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
            , date
            , _getChange
            , "SYSDATETIME()"
            , " "
            , StudentID
            );
            DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
        }

        public static void studRCagain(string date, string StudentID, string _getCount)
        {
            int _rollcallCount = Convert.ToInt32(_getCount);
            _rollcallCount = Convert.ToInt32(_getCount);
            string CommandStr = string.Format(
            "Update EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}"
            + " Set RollcallCount={1},RollcallTimes={2},IsUpdate={3} "
            //+ " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CourseID={3}"
            //+ " and "
            + " Where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID={4}"
            , date
            , (_rollcallCount + 1).ToString()
            , "SYSDATETIME()"
            , "1"
            , StudentID
            );
            DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
        }
        /// <summary>
        /// 第一次刷卡
        /// </summary>
        public static void studRCstart(string date, string StudentID, string _getCount, string _type)
        {
            string CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CardNoticeSet.CardTitle from  EnglishClassDBtest.dbo.Table_CardNoticeSet where EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg = '{0}'", _getCount);
            string CardTitle = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
            string _getCount2 = _getCount;
            if (_getCount2 != "")
            {
                if (CardTitle == "")
                {
                    do
                    {
                        _getCount2 = (Convert.ToInt16(_getCount2) - 1).ToString();
                        CommandStr = string.Format("Select EnglishClassDBtest.dbo.Table_CardNoticeSet.CardTitle from  EnglishClassDBtest.dbo.Table_CardNoticeSet where EnglishClassDBtest.dbo.Table_CardNoticeSet.numCardMsg = '{0}'", _getCount2);
                        CardTitle = DatabaseManager._databaseCore.strExecuteScalar(CommandStr);
                    } while (CardTitle == "");
                }
                CommandStr = string.Format(
                       "insert into EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} values('{1}', '{2}', '{3}', {4}, '{5}','{6}', '{7}')"
                       , date
                       , " "
                       , StudentID
                       , _getCount
                       , "SYSDATETIME()"
                       , _type
                       , CardTitle
                       , "1"
                       );
                DatabaseManager._databaseCore.ExecuteNonQuery(CommandStr);
            }

        }

        public static string AuthUUID(string date, string UUID)
        {
            DatabaseManager.Initialize();
            string studentID = "";
            try {

                string CommandStr = string.Format("select EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.StudentID " 
                    + " from EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0} "
                    + " where EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_{0}.CardNumber = '{1}'", date, UUID);
                studentID = DatabaseManager._databaseCoreRollcall.strExecuteScalar(CommandStr);
            }
            catch (Exception ex)
            {
                Log.Trace("SmartCardReader："+ex.ToString());
                //Console.WriteLine(ex.ToString());
                //return ex.ToString();
            }
            return studentID;
        }

       public static void funSmartCardReader()
        {
            try
            {
                // Establish SCard context
                SCardContext hContext = new SCardContext();
                hContext.Establish(SCardScope.System);

                // Retrieve the list of Smartcard readers
                string[] szReaders = hContext.GetReaders();
                if (szReaders.Length <= 0)
                    throw new PCSCException(SCardError.NoReadersAvailable,
                        "Could not find any Smartcard reader.");

                Console.WriteLine("reader name: " + szReaders[0]);

                // Create a reader object using the existing context
                SCardReader reader = new SCardReader(hContext);
                while (true) { 
                // Connect to the card
                    try
                    { 
                        SCardError err = reader.Connect(szReaders[0],
                        SCardShareMode.Shared,
                        SCardProtocol.T0 | SCardProtocol.T1);
                        CheckErr(err);

                        long pioSendPci;
                        switch (reader.ActiveProtocol)
                        {
                            case SCardProtocol.T0:
                                pioSendPci = (long)SCardPCI.T0;
                                break;
                            case SCardProtocol.T1:
                                pioSendPci = (long)SCardPCI.T1;
                                break;
                            default:
                                throw new PCSCException(SCardError.ProtocolMismatch,
                                    "Protocol not supported: "
                                    + reader.ActiveProtocol.ToString());
                        }
                    
                  
                    byte[] pbRecvBuffer = new byte[256];

                    byte[] get_id = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 };
                    err = reader.Transmit((IntPtr)pioSendPci, get_id, ref pbRecvBuffer);
                    CheckErr(err);

                    //Console.Write("uid: ");

                    string uid = BitConverter.ToString(pbRecvBuffer).Substring(0, 11);
                    uid = uid.Replace("-", "");
                    Console.WriteLine("UID: " + uid);
                        //for (int i = 0; i < pbRecvBuffer.Length-2; i++)
                        //    Console.Write("{0:X2} ", pbRecvBuffer[i]);
                    string studentID = AuthUUID(functionStudentRollcall.getDate, uid);

                    Console.WriteLine("studentID: " + studentID);

                    if (studentID != "") {
                        // Send SELECT command
                        //byte[] cmd1 = new byte[] { 0x00, 0xA4, 0x04, 0x00, 0x0A, 0xA0,
                        //    0x00, 0x00, 0x00, 0x62, 0x03, 0x01, 0x0C, 0x06, 0x01 };
                        pbRecvBuffer = new byte[256];
                        byte[] auth_ok = new byte[] { 0xFF, 0xE1, 0x02, 0x01, 0x0C, 0xA0, 0xFC, 0x4D, 0xA0, 0xFD, 0x20, 0xA0, 0xFE, 0x10, 0xA0, 0xFF, 0x01 };
                        err = reader.Transmit((IntPtr)pioSendPci, auth_ok, ref pbRecvBuffer);
                        CheckErr(err);

                        Console.Write("response: ");
                        for (int i = 0; i < pbRecvBuffer.Length; i++)
                            Console.Write("{0:X2} ", pbRecvBuffer[i]);
                        Console.WriteLine();
                        string _get_count = getCount(functionStudentRollcall.getDate, studentID);
                            //Console.Write(getCount("20180902", "1"));
                        if (_get_count != "")
                         {
                                studRCagain(functionStudentRollcall.getDate, studentID, _get_count);
                                Console.Write(getCount(functionStudentRollcall.getDate, studentID).ToString());

                         }
                        else
                        {
                                studRCstart(functionStudentRollcall.getDate, studentID, "0", "A");
                                //studRCagain("20180902", "1", "0");
                        }
                            Thread.Sleep(2000);
                        }
                  else { 
                        pbRecvBuffer = new byte[256];

                        // Send test command
                        byte[] auth_fail = new byte[] { 0xFF, 0xE1, 0x02, 0x01, 0x0C, 0xA0, 0xFC, 0x8C, 0xA0, 0xFD, 0x04, 0xA0, 0xFE, 0x04, 0xA0, 0xFF, 0x04 };
                        err = reader.Transmit((IntPtr)pioSendPci, auth_fail, ref pbRecvBuffer);
                        CheckErr(err);

                        Console.Write("response: ");
                        for (int i = 0; i < pbRecvBuffer.Length; i++)
                            Console.Write("{0:X2} ", pbRecvBuffer[i]);
                        Console.WriteLine();
                        Thread.Sleep(2000);
                       }
                        //hContext.Release();
                    }
                catch (Exception e)
                {
                }
              }
            }
            catch (PCSCException ex)
            {
                Console.WriteLine("Ouch: "
                    + ex.Message
                    + " (" + ex.SCardError.ToString() + ")");
                Log.Trace("SmartCardReader：" + "Ouch: "
                    + ex.Message
                    + " (" + ex.SCardError.ToString() + ")");
            }
        }
    }
}