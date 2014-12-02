using System;

namespace CommonHelper.Log
{
    public enum ScorerCategory
    {
        Log4net = 0
    }

    public class LogFactory
    {
        public static ILogService GetScorer(ScorerCategory category, Type type)
        {
            if (category == ScorerCategory.Log4net)
            {
                return new LogService(type);
            }

            return null;
        }
    }
}
