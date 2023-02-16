using Boss.Auth.Domain.Interfaces.AppSecret;
using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.AppSecret;
using Boss.Auth.Repository.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.AppSecret
{
    public class AppSecretDomainService : BaseDomainService<SysAppSecret>, IAppSecretDomainService
    {
        private readonly IAppSecretRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AppSecretDomainService(IUnitOfWork unitOfWork,
            IAppSecretRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }

    }
}
