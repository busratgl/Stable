using Microsoft.EntityFrameworkCore;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Constants;
using Stable.Business.Concrete.Exceptions;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.GetMyTransactionDto;
using Stable.Repository.Abstract;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class GetMyTransactionProcess : IGetMyTransactionProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMyTransactionProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetMyTransactionDto> ExecuteAsync(GetMyTransactionRequest getMyTransactionRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetQuery()
            .Include(u => u.Accounts)
            .ThenInclude(a => a.Transactions)
            .FirstOrDefaultAsync(u => u.Id == getMyTransactionRequest.UserId, cancellationToken: cancellationToken);

            var selectedAccount = user.Accounts.FirstOrDefault(a => a.Id == getMyTransactionRequest.AccountId);
            if (selectedAccount != null)
            {
                throw new BusinessException(ExceptionMessage.AccountNotFound, "007");
            }

            var getMyTransactionDto = new GetMyTransactionDto();
            foreach (var transaction in selectedAccount.Transactions)
            {
                var transactionDto = new GetMyTransactionTransactionDto()
                {
                    Date = transaction.CreatedDate,
                    Description = transaction.Description
                };

                getMyTransactionDto.Transactions.Add(transactionDto);
            }

            return getMyTransactionDto;
        }
    }
}
