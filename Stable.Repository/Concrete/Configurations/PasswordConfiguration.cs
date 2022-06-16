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
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.HasKey(pw => pw.Id);
            builder.Property(pw => pw.Id).ValueGeneratedOnAdd();
            builder.Property(pw => pw.CreatedDate).IsRequired();
            builder.Property(pw => pw.ModifiedDate).IsRequired();
            builder.Property(pw => pw.IsDeleted).IsRequired();

            builder.ToTable("Passwords");
        }
    }
}
