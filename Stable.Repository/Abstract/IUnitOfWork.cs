﻿using System;
using System.Threading.Tasks;

namespace Stable.Repository.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAccountRepository Accounts { get; }
        IAccountTypeRepository AccountTypes { get; }
        IAddressRepository Addresses { get; }
        IBalanceRepository Balances { get; }
        ICorporateUserRepository CorporateUsers { get; }
        IEmailRepository Emails { get; }
        IPasswordRepository Passwords { get; }
        IIndividualUserRepository IndividualUsers { get; }
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }
        IUserIpAddressRepository UserIpAddresses { get; }
        Task<int> SaveAsync();

    }
}
