using Microsoft.EntityFrameworkCore;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Constants;
using Stable.Business.Concrete.Exceptions;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CreateAccountDto;
using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class CreateAccountProcess : ICreateAccountProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAccountProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAccountDto> ExecuteAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetQuery()
                .Include(u => u.Accounts)
                .ThenInclude(a => a.AccountType)
                .Include(a => a.Accounts)
                .ThenInclude(a => a.Balance)
                .ThenInclude(b => b.CurrencyType)
                .FirstOrDefaultAsync(u => u.Id == createAccountRequest.UserId, cancellationToken: cancellationToken);

            var isAccountAlreadyExist = user.Accounts.Any(a => a.AccountType.Name == createAccountRequest.AccountType && a.Balance.CurrencyType.Name == createAccountRequest.CurrencyType);
            if (isAccountAlreadyExist)
            {
                throw new BusinessException(ExceptionMessage.AccountTypeAlreadyExists, "005");
            }

            var account = new Account()
            {
                Name = createAccountRequest.AccountName,
                AccountNumber = Guid.NewGuid().ToString().Substring(0, 34),

                AccountType = new AccountType()
                {
                    Name = createAccountRequest.AccountType,

                },

                Balance = new Balance()
                {
                    Amount = 0,
                    CurrencyType = new CurrencyType()
                    {
                        Name = createAccountRequest.CurrencyType
                    }
                },
            };

            user.Accounts.Add(account);

            await _unitOfWork.Accounts.CreateAsync(account);
            await _unitOfWork.SaveAsync();

            return new CreateAccountDto() { Message = account.Name + ExceptionMessage.AccountCreatedSuccessfully };
        }
    }
}
