using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.User
{
    public class CaptchaImageDto
    {
        /// <summary>
        /// 验证码图片
        /// </summary>
        public string ImgData { set; get; }
        /// <summary>
        /// 请求ID
        /// </summary>
        public string Uuid { set; get; }
    }
}
