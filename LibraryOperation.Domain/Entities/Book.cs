

namespace LibraryOperation.Domain.Entities
{
    public class Book
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string ISBN { set; get; }
        public DateTime PublishedDate { set; get; }
        public virtual Author? Author { set; get; }
        public int AuthorId { set; get; }
        public virtual ICollection<Loan>? Loans { set; get; }
    }
}
