using Microsoft.EntityFrameworkCore;
using Stable.Entity.Concrete;
using Stable.Repository.Concrete.Configurations;

namespace Stable.Repository.Concrete.Context
{
    public class StableDbContext : DbContext
    {
        public DbSet<IndividualUser> IndividualUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CorporateUser> CorporateUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TR-ADN-9332JL3\SQLEXPRESS; Database = Stable; Trusted_Connection = True; Connect Timeout = 30; MultipleActiveResultSets = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CorporateUserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new IndividualUserConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
