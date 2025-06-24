namespace LibraryOperation.Application.Dtos.Loan;

public class UpdateLoanDto
{
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int BookId { set; get; }
    public int BorrowerId { set; get; }
}   