
using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOperation.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(b => b.Borrowers).WithOne(u => u.User).HasForeignKey(b => b.UserId);
        }
    }
}
