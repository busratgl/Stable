using System;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class TransactionDto
    {
        /// <summary>
        /// This property represents explanation of account activities 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This property specifies the time of account transactions
        /// </summary>
        public DateTime Date { get; set; }
    }
}
