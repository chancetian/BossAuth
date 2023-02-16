using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Repository.Repository.Menu
{
    public class MenuAuthRepository : BaseRepository<SysMenuAuth>, IMenuAuthRepository
    {
        public MenuAuthRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
    
}
