using Boss.Auth.Domain.Interfaces.Department;
using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Domain.Services.Department
{
    public class DepartmentDomainService : BaseDomainService<SysDepartment>, IDepartmentDomainService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentDomainService(IUnitOfWork unitOfWork,
            IDepartmentRepository repository)
        {
            this._repository = repository;
            base._baseRepository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
