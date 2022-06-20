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
    public class IndividualUserConfiguration : IEntityTypeConfiguration<IndividualUser>
    {
        public void Configure(EntityTypeBuilder<IndividualUser> builder)
        {
            builder.HasKey(iu => iu.Id);
            builder.Property(iu => iu.Id).ValueGeneratedOnAdd();
            builder.Property(iu => iu.IdentityNumber).IsRequired();
            builder.HasIndex(iu => iu.IdentityNumber).IsUnique();
            builder.Property(iu => iu.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(iu => iu.LastName).IsRequired().HasMaxLength(50);
            builder.Property(iu => iu.BirthDate).IsRequired();
            builder.Property(iu => iu.CreatedDate).IsRequired();
            builder.Property(iu => iu.ModifiedDate).IsRequired();
            builder.Property(iu => iu.IsDeleted).IsRequired();


            builder.HasOne<User>(iu => iu.User).WithMany(u => u.IndividualUsers).HasForeignKey(iu => iu.UserId);
            builder.ToTable("People");
        }
    }
}
