using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Repository.Concrete.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(ad => ad.Id);
            builder.Property(ad => ad.Id).ValueGeneratedOnAdd();
            builder.Property(ad => ad.CreatedDate).IsRequired();
            builder.Property(ad => ad.ModifiedDate).IsRequired();
            builder.Property(ad => ad.IsDeleted).IsRequired();

           

            builder.ToTable("Addresses");

        }
    }
}
