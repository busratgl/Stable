using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using Stable.Repository.Concrete.EntityFramework;

namespace Stable.Repository.Concrete.Repositories
{
    public class CorporateUserRepository : BaseRepository<CorporateUser>, ICorporateUserRepository
    {
        public CorporateUserRepository(StableDbContext stableDbContext) : base(stableDbContext)
        {
        }
    }
}
