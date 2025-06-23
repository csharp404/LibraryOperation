namespace LibraryOperation.Domain.Entities
{
    public class Borrower
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }

        public int UserId { set; get; }
        public virtual User? User { set; get; }

        public virtual ICollection<Loan>? Loans { set; get; }
    }
}
