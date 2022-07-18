using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stable.Entity.Concrete;

namespace Stable.Repository.Concrete.Configurations
{
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.HasKey(pw => pw.Id);
            builder.Property(pw => pw.Id).ValueGeneratedOnAdd();
            builder.Property(pw => pw.CreatedDate).IsRequired();
            builder.Property(pw => pw.PasswordText).IsRequired();
            builder.Property(pw => pw.ModifiedDate).IsRequired();
            builder.Property(pw => pw.IsDeleted).IsRequired();
            builder.Property(pw => pw.IsActivePassword).IsRequired();

            builder.HasOne<User>(pw => pw.User).WithMany(u => u.Passwords).HasForeignKey(pw => pw.UserId);
            builder.ToTable("Passwords");
        }
    }
}
