using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.IService;

public interface IBookService
{
    Task<List<Book?>> GetBooksAsync();
    Task<Book> GetBookAsync(int id);
    Task<bool> DeleteBookAsync(int id);

    Task<bool> UpdateBookAsync(int id, UpdateBookDto model);
    Task<bool> CreateBookAsync(CreateBookDto model);
}