using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class BalanceDto
    {
        public decimal Amount { get; set; }
        public string CurrencyTypeName { get; set; }

    }
}
