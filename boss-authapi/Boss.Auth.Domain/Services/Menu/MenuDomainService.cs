using Boss.Auth.Domain.Interfaces.Menu;
using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.Menu
{
    public class MenuDomainService : BaseDomainService<SysMenu>, IMenuDomainService
    {
        private readonly IMenuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuDomainService(IUnitOfWork unitOfWork,
            IMenuRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }

    }
}
