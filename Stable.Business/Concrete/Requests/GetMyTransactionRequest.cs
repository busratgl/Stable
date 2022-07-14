using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Requests
{
    public class GetMyTransactionRequest
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
    }
}
