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
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();

            builder.ToTable("Balances");
        }
    }
}
