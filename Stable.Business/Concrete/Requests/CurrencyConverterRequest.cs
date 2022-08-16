namespace Stable.Business.Concrete.Requests
{
    public class CurrencyConverterRequest
    {
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
