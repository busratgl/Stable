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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(u => u.UserType).IsRequired().HasColumnType("tinyint");
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedDate).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();


            builder.ToTable("Users");
        }
    }
}
