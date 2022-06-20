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
    public class CorporateUserConfiguration : IEntityTypeConfiguration<CorporateUser>
    {
        public void Configure(EntityTypeBuilder<CorporateUser> builder)
        {
            builder.HasKey(cu => cu.Id);
            builder.Property(cu => cu.Id).ValueGeneratedOnAdd();
            builder.Property(cu => cu.TaxNumber).IsRequired();
            builder.HasIndex(cu => cu.TaxNumber).IsUnique();
            builder.Property(cu => cu.Name).IsRequired().HasMaxLength(150);
            builder.Property(cu => cu.CreatedDate).IsRequired();
            builder.Property(cu => cu.ModifiedDate).IsRequired();
            builder.Property(cu => cu.IsDeleted).IsRequired();

            builder.HasOne<User>(cu => cu.User).WithMany(u => u.CorporateUsers).HasForeignKey(cu => cu.UserId);
            builder.ToTable("CorporateUsers");
        }
    }
}
