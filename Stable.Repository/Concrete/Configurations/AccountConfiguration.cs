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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(150);
            //builder.Property(a => a.Type).IsRequired().HasColumnType("tinyint");
            builder.Property(a => a.Status).IsRequired().HasColumnType("tinyint");
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();


            builder.HasOne<Person>(x => x.Person).WithMany(x => x.Accounts).HasForeignKey(x => x.PersonId);

            builder.ToTable("Accounts");


        }
    }
}
