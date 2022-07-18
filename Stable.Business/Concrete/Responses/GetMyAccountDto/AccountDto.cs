using Stable.Core.Enums;
using System.Collections.Generic;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class AccountDto
    {
        public AccountDto()
        {
            this.Transactions = new List<TransactionDto>();
        }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTypeName { get; set; }
        public AccountStatus Status { get; set; }
        public List<TransactionDto> Transactions { get; set; }
        public BalanceDto Balance { get; set; }
    }
}
