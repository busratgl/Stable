using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Requests
{
    public class BuyingCurrencyRequest
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
