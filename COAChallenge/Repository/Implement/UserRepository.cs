using COAChallenge.DataAccess;
using COAChallenge.DataAccess.ModelsEF;
using COAChallenge.UnitOfWork;

namespace COAChallenge.Repository.Implement
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(COAContext context) : base(context)
        {

        }
    }
}
