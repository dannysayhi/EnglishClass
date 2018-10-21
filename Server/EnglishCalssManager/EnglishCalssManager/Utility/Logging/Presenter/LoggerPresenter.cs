using System;

namespace AOISystem.Utility.Logging.Presenter
{
    /// <summary>
    /// Interface Log Target
    /// </summary>
    public interface ILoggerTarget
    {
        void SetCommandLine(string obj);
    }
    /// <summary>
    /// Logger Presenter
    /// </summary>
    public class LoggerPresenter:IDisposable
    {
        private readonly ILoggerTarget _LoggerTargetView;

        /// <summary>
        /// Log Presenter
        /// </summary>
        /// <param name="logTargetView"></param>
        public LoggerPresenter(ILoggerTarget logTargetView )
        {
            _LoggerTargetView = logTargetView;

            if (Log.ShowLog == null)
            {
                Log.ShowLog += delegate(string obj)
                {
                    _LoggerTargetView.SetCommandLine(obj);
                }; 
            }
        }

        
        /// <summary>
        /// Close Log Delegate.
        /// </summary>
        public void Dispose()
        {
            Log.ShowLog = null;
        }
    }
}
