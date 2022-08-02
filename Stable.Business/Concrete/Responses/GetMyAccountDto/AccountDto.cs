using System.Collections.Generic;
using Stable.Core.Utilities.Results.ComplexTypes.Enums;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class AccountDto
    {
        public AccountDto()
        {
            this.Transactions = new List<TransactionDto>();
        }
        /// <summary>
        /// This property represents name of an account(such as my dollar account)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property refers to international bank account number(iban)
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// This property represents account type name(e.g.,checking,deposit.)
        /// </summary>
        public string AccountTypeName { get; set; }

        /// <summary>
        /// This property represents status of account(such as active, passive.)
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// This property represents account activities 
        /// </summary>
        public List<TransactionDto> Transactions { get; set; }

        /// <summary>
        /// This property represents balance of an account
        /// </summary>
        public BalanceDto Balance { get; set; }
    }
}
