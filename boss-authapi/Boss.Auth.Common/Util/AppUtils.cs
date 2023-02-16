using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Util
{
    public class AppUtils
    {
        /// <summary>
        /// 生成AppId
        /// </summary>
        /// <returns></returns>
        public static string GetAppId()
        {
            var num = 8;
            var uuid = StringHelper.GetUUID();
            var sb = new StringBuilder();
            string readyStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] rtn = new char[num];
            var guid = Guid.NewGuid();
            var ba = guid.ToByteArray();
            for (var i = 0; i < num; i++)
            {
                rtn[i] = readyStr[((ba[i] + ba[num + i]) % 35)];
            }
            foreach (char r in rtn)
            {
                sb.Append(r);
            }
            return sb.ToString();
        }
        /// <summary>
        /// sha1(appid+uuid) 生成AppSecret
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static String GetAppSecret(string appId)
        {
            var sb = new StringBuilder();
            var uuid = StringHelper.GetUUID();
            sb.Append(appId).Append(uuid);
            var secret = SecurityHelper.SHA1(sb.ToString());
            return secret;
        }
    }
}