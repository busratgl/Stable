using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Requests
{
    public class CreateAccountRequest
    {
        public long UserId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string CurrencyType { get; set; }
    }
}
