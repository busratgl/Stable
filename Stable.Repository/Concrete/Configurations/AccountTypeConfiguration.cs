using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasKey(act => act.Id);
            builder.Property(act => act.Id).ValueGeneratedOnAdd();
            builder.Property(act => act.Name).IsRequired().HasMaxLength(50);
            builder.Property(act => act.CreatedDate).IsRequired();
            builder.Property(act => act.ModifiedDate).IsRequired();
            builder.Property(act => act.IsDeleted).IsRequired();

            builder.ToTable("AccountTypes");

            builder.HasData(new AccountType()
            {
                Id = 1,
                Name = "Checking Account",

            });

            builder.HasData(new AccountType()
            {
                Id = 2,
                Name = "Deposit Account",

            });
        }
    }
}
