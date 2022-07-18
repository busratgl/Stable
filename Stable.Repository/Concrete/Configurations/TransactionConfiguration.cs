using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.ModifiedDate).IsRequired();
            builder.Property(t => t.IsDeleted).IsRequired();

            builder.HasOne<Account>(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountId);
            builder.ToTable("Transactions");

        }
    }
}
