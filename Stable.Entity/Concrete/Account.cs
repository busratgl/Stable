using Stable.Core.Entities.Abstract;
using System.Collections.Generic;
using Stable.Core.Utilities.Results.ComplexTypes.Enums;

namespace Stable.Entity.Concrete
{
    public class Account : EntityBase
    {
        public Account()
        {
            this.Transactions = new List<Transaction>();
        }

        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public long AccountTypeId { get; set; }
        public AccountStatus Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public Balance Balance { get; set; }
        public long BalanceId { get; set; }
        public bool IsActiveAccount { get; set; }
    }
}
