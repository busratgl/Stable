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
    public class UserIpAddressConfiguration : IEntityTypeConfiguration<UserIpAddress>
    {
        public void Configure(EntityTypeBuilder<UserIpAddress> builder)
        {
            builder.HasKey(uip => uip.Id);
            builder.Property(uip => uip.Id).ValueGeneratedOnAdd();
            builder.Property(uip=> uip.RemoteIpAddress).IsRequired();
            builder.Property(uip => uip.CreatedDate).IsRequired();
            builder.Property(uip => uip.ModifiedDate).IsRequired();
            builder.Property(uip => uip.IsDeleted).IsRequired();

            builder.HasOne<User>(uip => uip.User).WithMany(u => u.UserIpAddresses).HasForeignKey(uip => uip.UserId);
            builder.ToTable("UserIpAddresses");
        }
    }
}
