
using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibraryOperation.Infrastructure.EntityConfiguration
{
    public class AuthorConfiguration :IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(a => a.AuthorId);
        }
    }
}
