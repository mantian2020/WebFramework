using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public static class ExtendObject
    {
        public static int ToInt(this object value)
        {
            int temp = 0;
            if (value != null && value != DBNull.Value)
            {
                temp = Convert.ToInt32(value);
            }
            return temp;
        }

        public static string ToStrings(this object value)
        {
            if (value != null && value != DBNull.Value)
            {
                return value.ToString();
            }
            return string.Empty;
        }

        public static DateTime ToTime(this object value)
        {
            if (value != null && value != DBNull.Value)
            {
                return Convert.ToDateTime(value);
            }
            return DateTime.Now;
        }

        public static long ToLong(this object value)
        {
            if (value != null && value != DBNull.Value)
            {
                return Convert.ToInt64(value);
            }
            return 0;
        }

        public static decimal ToDecimal(this object value)
        {
            if (value != null && value != DBNull.Value)
            {
                return Convert.ToDecimal(value);
            }
            return 0;
        }
    }
}
