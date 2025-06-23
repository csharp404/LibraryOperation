
using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOperation.Infrastructure.EntityConfiguration
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.HasOne(u => u.User).WithMany(b => b.Borrowers).HasForeignKey(u => u.UserId);
            builder.HasMany(l => l.Loans).WithOne(b => b.Borrower).HasForeignKey(b => b.BorrowerId);
        }
    }
}
