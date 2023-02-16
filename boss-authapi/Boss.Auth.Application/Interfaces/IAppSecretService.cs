using Boss.Auth.Model.ViewModels.Req;
using Boss.Auth.Model.ViewModels.Req.AppSecret;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Auth.Model.ViewModels.Res.AppSecret;

namespace Boss.Auth.Application.Interfaces
{
    public interface IAppSecretService
    {
        /// <summary>
        /// 添加应用
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> AddAppSecret(AddAppSecretReq req);
        /// <summary>
        /// 获取应用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<AppSecretDto>> GetAppSecret(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<PageDto<AppSecretDto>>> GetPageList(GetAppSecretPageListReq req);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> Update(SysAppSecretReq req);
    }
}
