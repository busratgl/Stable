using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using Stable.Repository.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Repository.Concrete.Repositories
{
    public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(StableDbContext stableDbContext) : base(stableDbContext)
        {
        }
    }
}
