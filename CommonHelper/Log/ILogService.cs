using System;

namespace CommonHelper.Log
{
    public interface ILogService
    {
        void Debug(object message, Exception exception);

        void Debug(object message);

        void Error(object message, Exception exception);

        void Error(object message);

        void Fatal(object message, Exception exception);

        void Fatal(object message);

        void Info(object message, Exception exception);

        void Info(object message);

        void Warn(object message, Exception exception);

        void Warn(object message);
    }
}
