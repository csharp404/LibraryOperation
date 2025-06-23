
using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOperation.Infrastructure.EntityConfiguration
{
    public class LoanConfiguration :IEntityTypeConfiguration<Loan>  
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasOne(b => b.Book).WithMany(l => l.Loans).HasForeignKey(b => b.BookId);
            builder.HasOne(b => b.Borrower).WithMany(l => l.Loans).HasForeignKey(b => b.BorrowerId);
        }
    }
}
