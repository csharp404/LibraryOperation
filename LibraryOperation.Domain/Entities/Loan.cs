namespace LibraryOperation.Domain.Entities
{
    public class Loan
    {

        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int BookId { set; get; }
        public virtual Book? Book { set; get; }

        public virtual Borrower? Borrower { set; get; }
        public int BorrowerId { set; get; }
    }
}



