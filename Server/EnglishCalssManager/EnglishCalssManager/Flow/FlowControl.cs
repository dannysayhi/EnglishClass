using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishClassManager.Flow
{
    public class FlowControl
    {
        #region Parameter    
        /// <summary> 系統狀態 </summary>
        public ProcessState processState = ProcessState.NONE;
        public bool bError = false;
        #endregion
        //

        public FlowControl()
        {
            //Initalize

            //Start    
            //Flow_ConnectControl.StartFlow();
            //Flow_PLC_StatusUpdate.StartFlow();
            //Flow_PLC_ForRobotData.StartFlow();

        }
        public void StartAllFlow()
        {
            //HandshakeProcessPLC.WriteWordData();
            //Flow_Robot_Left.StartFlow();
            //Flow_Robot_Right.StartFlow();
        }
        public void StopAllFlow()
        {
            //Flow_Robot_Left.StopFlow();
            //Flow_Robot_Right.StopFlow();
        }
        public enum ProcessState
        {
            RUN = 1,
            IDEL = 2,
            DOWN = 3,
            NONE = 4
        }
    }
   
}
