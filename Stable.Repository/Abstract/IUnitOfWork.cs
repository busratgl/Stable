using System.Threading.Tasks;

namespace Stable.Repository.Abstract
{
    public interface IUnitOfWork
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
        Task<int> SaveAsync();
    }
}
