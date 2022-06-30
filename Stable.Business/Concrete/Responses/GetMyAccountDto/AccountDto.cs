using Stable.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class AccountDto
    {
        public AccountDto()
        {
            this.Transactions = new List<TransactionDto>();
        }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTypeName { get; set; }
        public AccountStatus Status { get; set; }
        public List<TransactionDto> Transactions { get; set; }
        public BalanceDto Balance { get; set; }
    }
}
