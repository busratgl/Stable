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
            builder.HasKey(adr => adr.Id);
            builder.Property(adr => adr.Id).ValueGeneratedOnAdd();
            builder.Property(adr => adr.Name).IsRequired().HasMaxLength(150);
            builder.Property(adr => adr.CreatedDate).IsRequired();
            builder.Property(adr => adr.ModifiedDate).IsRequired();
            builder.Property(adr => adr.IsDeleted).IsRequired();
            builder.Property(adr => adr.IsActiveAddress).IsRequired();


            builder.HasOne<User>(adr => adr.User).WithMany(u => u.Addresses).HasForeignKey(adr => adr.UserId);
            builder.ToTable("Addresses");
        }
    }
}
