using Stable.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Stable.Entity.Concrete
{
    public class AccountType : EntityBase
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
