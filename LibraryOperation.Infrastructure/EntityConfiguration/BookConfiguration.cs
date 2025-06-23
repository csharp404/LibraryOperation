
using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOperation.Infrastructure.EntityConfiguration
{
    public class BookConfiguration :IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(a => a.AuthorId);
            builder.HasMany(l => l.Loans).WithOne(b => b.Book).HasForeignKey(b => b.BookId);
        }
    }
}
