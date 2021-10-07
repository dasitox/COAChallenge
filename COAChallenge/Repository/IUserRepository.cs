using COAChallenge.DataAccess.ModelsEF;
using COAChallenge.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COAChallenge.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        
    }
}
