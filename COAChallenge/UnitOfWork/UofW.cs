using COAChallenge.DataAccess;
using COAChallenge.DataAccess.ModelsEF;
using COAChallenge.Repository;
using COAChallenge.Repository.Implement;
using System;
using System.Linq;

namespace COAChallenge.UnitOfWork
{
    public interface IUofW : IDisposable
    {
        COAContext Context { get; }
        IUserRepository UserRepository { get; }
        bool UserExist(User user);
        void Commit();
    }
    public class UofW : IUofW
    {
        public COAContext Context { get; }
        private IUserRepository userRepository;

        public UofW(COAContext context)
        {
            Context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null) this.userRepository = new UserRepository(Context);
                return userRepository;
            }
        }

        public bool UserExist(User user)
        {
            bool res = Context.User.Any(u => u.Name.ToLower() == user.Name.ToLower() || u.Email.ToLower() == user.Email.ToLower() || u.Telephone == user.Telephone);
            return res;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
