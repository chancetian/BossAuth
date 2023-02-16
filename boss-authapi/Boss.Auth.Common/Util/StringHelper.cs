using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Util
{
    public class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetUUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
