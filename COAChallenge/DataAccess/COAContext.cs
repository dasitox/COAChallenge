using COAChallenge.DataAccess.ModelsEF;
using Microsoft.EntityFrameworkCore;

namespace COAChallenge.DataAccess
{
    public class COAContext : DbContext
    {
        public COAContext(DbContextOptions<COAContext> options) : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }
    }
}
