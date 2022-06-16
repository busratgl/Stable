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

            builder.ToTable("Account Types");
        }
    }
}
