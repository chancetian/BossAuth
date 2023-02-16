using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Extensions
{
    public static class ObjExtensions
    {
        /// <summary>
        /// 数据转换为int类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt(this object val)
        {
            int result = 0;
            if (val == null)
                return 0;
            return val != null && int.TryParse(val.ToString(), out result) ? result : result;
        }

        /// <summary>
        /// 数据转换为Double类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToDouble(this object val)
        {
            double result = 0.0;
            return val != null && double.TryParse(val.ToString(), out result) ? result : 0.0;
        }

        /// <summary>
        /// 数据转换为Float类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float ToFloat(this object val)
        {
            float result = 0;
            return val != null  && float.TryParse(val.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 数据转换为String类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToString(this object val)
        {
            return val != null ? val.ToString().Trim() : "";
        }


        /// <summary>
        /// 数据转换为Decimal类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(this object val)
        {
            Decimal result = new Decimal();
            return val != null  && Decimal.TryParse(val.ToString(), out result) ? result : Decimal.Zero;
        }

        /// <summary>
        /// 数据转换为DateTime类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DateTime ToDate(this object val)
        {
            DateTime result = DateTime.MinValue;
            if (val != null  && DateTime.TryParse(val.ToString(), out result))
                result = Convert.ToDateTime(val);
            return result;
        }

        /// <summary>
        /// 数据转换为bool类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool ToBool(this object val)
        {
            bool result = false;
            return val != null  && bool.TryParse(val.ToString(), out result) ? result : result;
        }
    }
}
