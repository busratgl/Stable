using Stable.Core.Enums;
using Stable.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class GetMyAccountDto
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus Status { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Balance Balance { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        
    }
}
