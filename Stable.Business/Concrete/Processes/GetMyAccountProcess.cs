using Microsoft.EntityFrameworkCore;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Constants;
using Stable.Business.Concrete.Exceptions;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
using Stable.Core.Utilities.Results.ComplexTypes.Enums;
using Stable.Repository.Abstract;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class GetMyAccountProcess : IGetMyAccountProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMyAccountProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetMyAccountDto> ExecuteAsync(GetMyAccountRequest getMyAccountRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetQuery()
                .Include(u => u.Accounts)
                .ThenInclude(a => a.AccountType)
                .Include(a => a.Accounts)
                .ThenInclude(a => a.Balance)
                .ThenInclude(b => b.CurrencyType)
                .Include(a => a.Accounts)
                .ThenInclude(a => a.Transactions).FirstOrDefaultAsync(u => u.Id == getMyAccountRequest.UserId && u.Accounts.Any(a => a.Status == AccountStatus.Active), cancellationToken: cancellationToken);


            if (user.Accounts == null)
            {
                throw new BusinessException(ExceptionMessage.AccountInformationNotVisible, "006");
            }

            var result = new GetMyAccountDto();

            foreach (var account in user.Accounts)
            {
                var accountDto = new AccountDto
                {
                    Status = account.Status,
                    AccountNumber = account.AccountNumber,
                    AccountTypeName = account.AccountType.Name,
                    Name = account.Name,
                    Balance = new BalanceDto()
                    {
                        Amount = account.Balance.Amount,
                        CurrencyTypeName = account.Balance.CurrencyType.Name,
                    }
                };

                foreach (var transaction in account.Transactions)
                {
                    var transactionDto = new TransactionDto()
                    {
                        Date = transaction.CreatedDate,
                        Description = transaction.Description
                    };

                    accountDto.Transactions.Add(transactionDto);
                }

                result.Accounts.Add(accountDto);
            }

            return result;

        }
    }
}


