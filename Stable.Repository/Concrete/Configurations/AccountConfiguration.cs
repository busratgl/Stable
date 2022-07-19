using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.AccountNumber).IsRequired().HasMaxLength(34);
            builder.HasIndex(a => a.AccountNumber).IsUnique();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Status).IsRequired().HasColumnType("tinyint");
            builder.Property(a => a.IsActiveAccount).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();

            builder.HasOne<User>(a => a.User).WithMany(u => u.Accounts).HasForeignKey(a => a.UserId);
            builder.HasOne<Balance>(a => a.Balance).WithOne(b => b.Account).HasForeignKey<Account>(a => a.BalanceId);
            builder.HasOne<AccountType>(a => a.AccountType).WithMany(acty => acty.Accounts).HasForeignKey(a => a.AccountTypeId);
            builder.ToTable("Accounts");
        }
    }
}
