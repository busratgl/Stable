using System.Collections.Generic;

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
