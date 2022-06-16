using Stable.Core.Entities.Abstract;
using Stable.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public long AccountTypeId { get; set; }
        public AccountStatus Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Person Person { get; set; }
        public long PersonId { get; set; }




    }
}
