using Stable.Core.Entity;
using Stable.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity
{
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Person Person { get; set; }
        public long PersonId { get; set; }




    }
}
