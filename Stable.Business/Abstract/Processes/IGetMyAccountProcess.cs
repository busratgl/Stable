using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Abstract.Processes
{
    public interface IGetMyAccountProcess
    {
        Task<GetMyAccountDto> ExecuteAsync(GetMyAccountRequest getMyAccountRequest, CancellationToken cancellationToken);
    }
}
