using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using Stable.Repository.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StableDbContext _context;
        private AccountRepository _accountRepository;
        private AccountTypeRepository _accountTypeRepository;
        private AddressRepository _addressRepository;
        private BalanceRepository _balanceRepository;
        private CorporateUserRepository _corporateUserRepository;
        private EmailRepository _emailRepository;
        private PasswordRepository _passwordRepository;
        private IndividualUserRepository _individualUserRepository;
        private TransactionRepository _transactionRepository;
        private UserRepository _userRepository;

        public UnitOfWork(StableDbContext context)
        {
            _context = context;
        }

        public IAccountRepository Accounts => _accountRepository ?? new AccountRepository(_context);
        //Null Coalescing Operatörü(??)
        public IAccountTypeRepository AccountTypes => _accountTypeRepository ?? new AccountTypeRepository(_context);

        public IAddressRepository Addresses => _addressRepository ?? new AddressRepository(_context);

        public IBalanceRepository Balances => _balanceRepository ?? new BalanceRepository(_context);

        public IEmailRepository Emails => _emailRepository ?? new EmailRepository(_context);

        public IPasswordRepository Passwords => _passwordRepository ?? new PasswordRepository(_context);
        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public ITransactionRepository Transactions => _transactionRepository ?? new TransactionRepository(_context);

        public ICorporateUserRepository CorporateUsers => _corporateUserRepository ?? new CorporateUserRepository(_context);

        public IIndividualUserRepository IndividualUsers => _individualUserRepository ?? new IndividualUserRepository(_context);



        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
