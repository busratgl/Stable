using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Helpers.Models
{
    public class GetCurrencyModelItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuyingRate { get; set; }
        public decimal BanknoteSellingRate { get; set; }

    }
}
