using Boss.Auth.Model.Entites;
using Boss.Auth.Repository.Interfaces;
using Boss.Auth.Repository.Interfaces.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Repository.Repository.Position
{
    public class PositionRepository : BaseRepository<SysPosition>, IPositionRepository
    {
        public PositionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
