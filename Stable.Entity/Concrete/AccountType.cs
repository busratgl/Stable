using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class AccountType : EntityBase
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
