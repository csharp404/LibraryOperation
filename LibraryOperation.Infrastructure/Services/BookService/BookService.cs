using AutoMapper;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.BookService;

public class BookService (IRepository<Book> bookRepository, IMapper mapper) : IBookService
{
    public async Task<List<Book?>> GetBooksAsync()
    {
        return await bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookAsync(int id)
    {
        Book? book= await bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            throw new KeyNotFoundException("a user is not found");
        }
        return book;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        bool result  = await bookRepository.DeleteByIdAsync(id);
        return result;
    }

    public async  Task<bool> UpdateBookAsync(int id, UpdateBookDto model)
    {
        Book book = mapper.Map<Book>(model);
        bool result = await bookRepository.UpdateAsync(id, book);
        return result;
    }

    public async Task<bool> CreateBookAsync(CreateBookDto model)
    {
        Book book = mapper.Map<Book>(model);
        bool result  = await bookRepository.CreateAsync(book);
        return result;
    }
}