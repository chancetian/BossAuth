using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.AppSecret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Repository.Repository.AppSecret
{
    public class AppSecretRepository : BaseRepository<SysAppSecret>, IAppSecretRepository
    {
        public AppSecretRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
