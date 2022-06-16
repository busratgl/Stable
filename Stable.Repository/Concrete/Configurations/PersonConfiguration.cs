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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.IdentityNumber).IsRequired();
            builder.HasIndex(p => p.IdentityNumber).IsUnique();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(75);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.ToTable("People");


        }
    }
}
