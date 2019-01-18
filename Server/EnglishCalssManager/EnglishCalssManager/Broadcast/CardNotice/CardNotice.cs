using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace EnglishCalssManager.Broadcast.CardNotice
{
   public class CardNotice
    {
        public static String SendNotificationFromFirebaseCloud(String Title, String Message)
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAA9W25YKA:APA91bE4aCDtVqe_JIOWt3NFqXsSnERtVHxGXFqId4RRx8jFVaxSLP0MORI5_qLo0qtKTpGV5wyQi4hxdR4Njiwmeuf0vZqKyjVyt8QjRaKEcIvvHRPfDlbj_rbnCt7h_elp2H2HLzuA");
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = @"{
                    ""to"": ""df_YjBowjKU:APA91bHPebenLVN7kVycskhvBNCKf6iGfy_5lReJ5-ID1I36XUYMe4ELwY9LCqicwpixj60xvwJrFZKVGL7exHrJaXeES_vcalMpxv5KXyVeObY30mI3BpRHfUDq33uhDXiu5YMEV_yA"",
                    ""data"": {
                        ""ShortDesc"": ""Some short desc"",
                        ""IncidentNo"": ""any number"",
                        ""Description"": ""detail desc""
                      },
                      ""notification"": {
                                    ""title"":" + @"""" + @"" + Title + @"" + @"""" + @",
                        ""text"":" + @"""" + @"" + Message + @"" + @"""" + @",
                    ""sound"":""default""
                      }
                }";

                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
