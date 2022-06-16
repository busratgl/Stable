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
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.ModifiedDate).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();

            builder.ToTable("Emails");

        }
    }
}
