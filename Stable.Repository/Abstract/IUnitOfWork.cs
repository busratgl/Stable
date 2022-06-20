using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Repository.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAccountRepository Accounts { get; } // unitOfWork.Accounts
        IAccountTypeRepository AccountTypes { get; }
        IAddressRepository Addresses { get; }
        IBalanceRepository Balances { get; }
        ICorporateUserRepository CorporateUsers { get; }
        IEmailRepository Emails { get; }
        IPasswordRepository Passwords { get; }
        IIndividualUserRepository IndividualUsers { get; } //_unitOfWork.People.CreateAsync(person); //_unitOfWork.SaveAsync();
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }


        Task<int> SaveAsync();


    }
}
