using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.GetMyTransactionDto;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IGetMyTransactionProcess
    {
        Task<GetMyTransactionDto> ExecuteAsync(GetMyTransactionRequest getMyTransactionRequest, CancellationToken cancellationToken);
    }
}
