using System;

using log4net;
using log4net.Core;
using log4net.Config;

namespace CommonHelper.Log
{
    internal class LogService : ILogService
    {
        private ILog logger;

        static LogService()
        {
            XmlConfigurator.Configure();
        }

        public LogService(Type type)
        {
            this.logger = LogManager.GetLogger(type);

        }

        #region ILogService 成员

        public void Debug(object message, Exception exception)
        {
            logger.Debug(message, exception);

        }

        public void Debug(object message)
        {
            logger.Debug(message);
        }


        public void Error(object message, Exception exception)
        {
            logger.Error(message, exception);

        }

        public void Error(object message)
        {
            logger.Error(message);
        }

        public void Fatal(object message, Exception exception)
        {
            logger.Fatal(message, exception);
        }

        public void Fatal(object message)
        {
            logger.Fatal(message);
        }

        public void Info(object message, Exception exception)
        {
            logger.Info(message, exception);
        }

        public void Info(object message)
        {
            logger.Info(message);
        }    

        public void Warn(object message, Exception exception)
        {
            logger.Warn(message, exception);
        }

        public void Warn(object message)
        {
            logger.Warn(message);
        }

        #endregion
    }
}
