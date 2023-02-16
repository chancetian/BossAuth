using Boss.Auth.Application.Helper;
using Boss.Auth.Model.ViewModels.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Services
{
    public class BaseService
    {
        public JwtUserInfo jwtUserInfo=> HttpCurrentContext.GetUserInfo;

        public int UserId => jwtUserInfo.Id;

        public ResponseDto<string> Success()
        {
            return new ResponseDto<string>
            {
                Code=ResponseCode.Success,
                Message=""
            };
        }

        public ResponseDto<T> Success<T>(T data)
        {
            return new ResponseDto<T>
            {
                Code = ResponseCode.Success,
                Message = "",
                Data = data
            };
        }
        public ResponseDto<T> Fail<T>(string message)
        {
            return new ResponseDto<T>
            {
                Code = ResponseCode.Fail,
                Message = message
            };
        }

        public ResponseDto<string> Fail(string message)
        {
            return new ResponseDto<string>
            {
                Code = ResponseCode.Fail,
                Message = message
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public ResponseDto<T> Result<T>(ResponseCode code, string message)
        {
            return new ResponseDto<T>
            {
                Code = code,
                Message = message
            };
        }
    }
}
