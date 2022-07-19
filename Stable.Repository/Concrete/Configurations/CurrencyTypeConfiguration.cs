using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class CurrencyTypeConfiguration : IEntityTypeConfiguration<CurrencyType>
    {
        public void Configure(EntityTypeBuilder<CurrencyType> builder)
        {
            builder.HasKey(ctp => ctp.Id);
            builder.Property(ctp => ctp.Id).ValueGeneratedOnAdd();
            builder.Property(ctp => ctp.Name).IsRequired().HasMaxLength(50);
            builder.Property(ctp => ctp.CreatedDate).IsRequired();
            builder.Property(ctp => ctp.ModifiedDate).IsRequired();
            builder.Property(ctp => ctp.IsDeleted).IsRequired();

            builder.ToTable("CurrencyTypes");

            builder.HasData(new CurrencyType()
            {
                Id = 1,
                Name = "TL"
            });

            builder.HasData(new CurrencyType()
            {
                Id = 2,
                Name = "Dollar"
            });

            builder.HasData(new CurrencyType()
            {
                Id = 3,
                Name = "Euro"
            });

            builder.HasData(new CurrencyType()
            {
                Id = 4,
                Name = "Gold"
            });
        }
    }
}
