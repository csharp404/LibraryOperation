namespace LibraryOperation.Application.Dtos.Book;

public class CreateBookDto
{
    public string Title { set; get; }
    public string ISBN { set; get; }
    public int AuthorId { set; get; }
    public DateTime PublishedDate { set; get; }
}