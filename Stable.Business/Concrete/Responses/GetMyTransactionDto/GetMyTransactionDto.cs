using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Responses.GetMyTransactionDto
{
    public class GetMyTransactionDto
    {
        public GetMyTransactionDto()
        {
            this.Transactions = new List<GetMyTransactionTransactionDto>();
        }
        public List<GetMyTransactionTransactionDto> Transactions { get; set; }
    }
}
