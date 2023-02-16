using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Extensions
{
    public static partial class Extention
    { /// <summary>
      /// string转int
      /// </summary>
      /// <param name="str">字符串</param>
      /// <returns></returns>
        public static int ToInt(this string str)
        {
            str = str.Replace("\0", "");
            if (string.IsNullOrEmpty(str))
                return 0;
            return Convert.ToInt32(str);
        }
        /// <summary>
        /// string转int
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static int ToSafeInt(this string str, int defValue = 0)
        {
            if (int.TryParse(str, out int result))
            {
                return result;
            }
            return defValue;
        }
    }
}
