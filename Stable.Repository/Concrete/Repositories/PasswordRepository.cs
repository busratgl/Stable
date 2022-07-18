using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using Stable.Repository.Concrete.EntityFramework;

namespace Stable.Repository.Concrete.Repositories
{
    public class PasswordRepository : BaseRepository<Password>, IPasswordRepository
    {
        public PasswordRepository(StableDbContext stableDbContext) : base(stableDbContext)
        {
        }
    }
}
