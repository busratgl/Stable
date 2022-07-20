using Microsoft.EntityFrameworkCore;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Exceptions;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
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
                .ThenInclude(a => a.Transactions).FirstOrDefaultAsync(u => u.Id == getMyAccountRequest.UserId && u.Accounts.Any(a => a.Status == Core.Enums.AccountStatus.Active));


            if (user.Accounts == null)
            {
                throw new BusinessException("Hesap bilgileriniz görüntülenememektedir.", "006");
            }

            var result = new GetMyAccountDto();

            foreach (var account in user.Accounts)
            {
                var accountDto = new AccountDto();
                accountDto.Status = account.Status;
                accountDto.AccountNumber = account.AccountNumber;
                accountDto.AccountTypeName = account.AccountType.Name;
                accountDto.Name = account.Name;
                accountDto.Balance = new BalanceDto()
                {
                    Amount = account.Balance.Amount,
                    CurrencyTypeName = account.Balance.CurrencyType.Name,
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


