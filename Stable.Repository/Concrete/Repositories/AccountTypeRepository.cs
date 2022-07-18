using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using Stable.Repository.Concrete.EntityFramework;

namespace Stable.Repository.Concrete.Repositories
{
    public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(StableDbContext stableDbContext) : base(stableDbContext)
        {
        }
    }
}
