namespace LibraryOperation.Application.Dtos.Book;

public class UpdateBookDto
{
    public string? Title { set; get; }
    public string? ISBN { set; get; }
    public DateTime? PublishedDate { set; get; }
}