
using Boss.Auth.Domain.Interfaces.Position;
using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.Position
{
    public class PositionDomainService : BaseDomainService<SysPosition>, IPositionDomainService
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionDomainService(IUnitOfWork unitOfWork,
            IPositionRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }
    
    }
}
