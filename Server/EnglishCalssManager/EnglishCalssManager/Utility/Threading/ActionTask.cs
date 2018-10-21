using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _4RobotSystem.PCaGUtility.Threading
{
    class ActionTask
    {
        // 任務清單
        private List<ActionItem> totalTask;
        private int interval;
        private Thread cycleTaskThread;
        private bool isRunning;
        /// <summary> Task中是否有任務在運行 </summary>
        public bool IsRunning { get { return isRunning; } }
        //
        public ActionTask()
        {
            isRunning = false;
            totalTask = new List<ActionItem>();
        }

        /// <summary>
        /// 新增ActionItem 到ActionTask中，ActionItem名稱不能相同。
        /// </summary>
        public void Add(ActionItem item)
        {
            if (item != null)
            {
                if (totalTask.Count > 0)
                {
                    foreach (ActionItem eachItem in totalTask)
                    {
                        if (item.Name == eachItem.Name)
                        {
                            throw new ArgumentNullException("ActionItem.Name is repeated");
                        }
                    }
                    totalTask.Add(item);
                }
                else
                {
                    totalTask.Add(item);
                }
            }
            else
            {
                throw new ArgumentNullException("ActionItem Is Null");
            }
        }
        /// <summary>
        /// 將指定ActionItem.Switch改為true
        /// </summary>
        public void TurnOn(ActionItem item)
        {
            if (item != null)
            {
                foreach (ActionItem _item in totalTask)
                {
                    if( _item.Name == item.Name )
                    {
                        _item.Switch = true;
                        return;
                    }
                }
                throw new ArgumentNullException("ActionItem Is Not Found");
            }
            else
            {
                throw new ArgumentNullException("ActionItem Is Null");
            }
        }

        /// <summary>
        /// 將ActionTask中的所有ActionItem.Switch改為true
        /// </summary>
        public void TurnOnAll()
        {
            if (totalTask.Count > 0)
            {
                foreach (ActionItem _item in totalTask)
                {
                    _item.Switch = true;
                    _item.iStep = 0;
                }
            }
            else
            {
                throw new ArgumentNullException("ActionItem Is Null");
            }
        }

        /// <summary>
        /// 將指定ActionItem.Switch改為false
        /// </summary>
        /// <param name="item">ActionItem.</param>
        public void TurnOff(ActionItem item)
        {
            if (item != null)
            {                
                foreach (ActionItem _item in totalTask)
                {
                    if (_item.Name == item.Name)
                    {
                        _item.Switch = false;
                        _item.iStep = 0;
                        return;
                    }
                }
                throw new ArgumentNullException("ActionItem Is Not Found");
            }
            else
            {
                throw new ArgumentNullException("ActionItem Is Null");
            }
        }

        /// <summary>
        /// 將所有ActionItem.Switch改為false
        /// </summary>
        public void TurnOffAll()
        {
            if (totalTask.Count > 0)
            {
                foreach (ActionItem _item in totalTask)
                {
                    _item.Switch = false;
                    _item.iStep = 0;
                }
            }
            else
            {
                throw new ArgumentNullException("ActionItem Is Null");
            }
        }               

        /// <summary>
        /// Runs the task.
        /// </summary>
        /// <param name="type">
        /// <para>TaskRunType.Single: Thread只輪詢一次TaskList就停止，必須自己TurnOn(item)。[用法待驗證]</para>
        /// <para>TaskRunType.Cycle:Thread會一直輪詢TaskList，輪詢期間必須自己手動TurnOn(item)或TurnOff(item)。</para>
        /// <para>TaskRunType.Sequence:Thread只輪詢一次TaskList就停止，程式會依照Add的時間自動TurnOn(item)。[用法待驗證]</para>
        /// </param>
        /// <param name="interval">延遲執行時間.</param>
        public void Run(TaskRunType type, int interval)
        {
            this.interval = interval;
            switch (type)
            {
                //case TaskRunType.Once:
                //    onceTaskThread = new Thread(new ParameterizedThreadStart(delegate { singleRun(interval); }));
                //    onceTaskThread.IsBackground = true;
                //    onceTaskThread.Start();
                //    break;

                case TaskRunType.Cycle:
                    if (cycleTaskThread != null)
                    {
                        if (cycleTaskThread.IsAlive)
                        {
                            return;
                        }
                    }
                    cycleTaskThread = new Thread(new ParameterizedThreadStart(delegate { cycleRun(interval); }));
                    cycleTaskThread.IsBackground = true;
                    cycleTaskThread.Start();
                    break;

                    //case TaskRunType.Sequence:
                    //    sequenceTaskThread = new Thread(new ParameterizedThreadStart(delegate { sequenceRun(interval); }));
                    //    sequenceTaskThread.IsBackground = true;
                    //    sequenceTaskThread.Start();
                    //    break;
            }
        }

        /// <summary>
        /// Cycle run task.
        /// </summary>
        /// <param name="interval">The interval.</param>
        private void cycleRun(int interval)
        {
            while (true)
            {
                foreach (ActionItem eachTask in totalTask)
                {
                    if (eachTask.Switch == true)
                    {
                        try
                        {
                            if(cycleTaskThread.Name == null || cycleTaskThread.Name.Equals("")) cycleTaskThread.Name = eachTask.Name;
                            eachTask.iStep = eachTask.Func(eachTask.iStep);
                        }
                        catch (ObjectDisposedException)
                        {
                            Stop();
                        }                     
                    }
                }                
                Thread.Sleep(interval);
            }
        }

        /// <summary>
        /// <para>1. Stops the task(建議以ChangeSwitch將Switch改為false，即可再下一次運行停止該項目)。由於本方法是直接停止thread，
        /// 若欲再次執行task則必須再度建立thread，若是經常性的操作，將會損耗系統資源。</para>
        /// <para>2. 若正在執行Run的過程中，欲離開程式時，最好執行Stop來將流程停止與釋放Thread。</para>
        /// </summary>
        public void Stop()
        {
            if (cycleTaskThread != null)
            {
                try
                {
                    cycleTaskThread.Abort();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                isRunning = false;
            }
        }
    }
    public class ActionItem
    {        
        /// <summary> 任務名稱(在同一個ActionTask下，名字必須是唯一的。) </summary>
        public string Name { get; set; }
        /// <summary> 方法啟停 </summary>
        public bool Switch { get; set; }
        /// <summary>  要傳入的方法 </summary>
        public Func<int,int> Func { get; set; }
        /// <summary> 呼叫Switch Case步序時要傳入 </summary>
        public int iStep { get; set; }
        /// <summary> 流程命名 </summary>
        public ActionItem(string name, bool sw, Func<int,int> func)
        {
            this.Name = name;
            this.Switch = sw;
            this.Func = func;
            iStep = 0;
        }       
    }
    /// <summary>任務運轉模式-連續或是單次或是順序</summary>
    public enum TaskRunType
    {
        //None,
        //Once,
        //Sequence,
        Cycle
    }

}
