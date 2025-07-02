namespace LibraryOperation.Domain.Entities
{
    public class Author :BaseEntity
    {


        public string Bio { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
