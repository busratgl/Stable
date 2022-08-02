namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class BalanceDto
    {
        /// <summary>
        /// This property represents sum in the account
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// This property represents currency type name(e.g.,TL,Euro.)
        /// </summary>
        public string CurrencyTypeName { get; set; }
    }
}
