using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Amount);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();

            builder.HasOne<CurrencyType>(b => b.CurrencyType).WithMany(c => c.Balances).HasForeignKey(b => b.CurrencyTypeId);
            builder.ToTable("Balances");
        }
    }
}
