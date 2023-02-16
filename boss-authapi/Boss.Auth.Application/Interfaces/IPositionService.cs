using Boss.Auth.Model.ViewModels.Req.Position;
using Boss.Auth.Model.ViewModels.Res;
using Boss.Auth.Model.ViewModels.Res.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Application.Interfaces
{
    public interface IPositionService
    {
        Task<ResponseDto<string>> Add(AddOrUpdatePositionReq req);

        Task<ResponseDto<string>> Update(AddOrUpdatePositionReq req);

        Task<ResponseDto<string>> Delete(int id);

        Task<ResponseDto<PositionDto>> QueryByID(int id);

        Task<ResponseDto<PageDto<PositionDto>>> GetList(PositionListReq req);

        Task<ResponseDto<int>> GetMaxSort();
    }
}