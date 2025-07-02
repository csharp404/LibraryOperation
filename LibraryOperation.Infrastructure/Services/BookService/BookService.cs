using AutoMapper;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.Exception;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Constants;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.BookService;

public class BookService (IRepository<Book> bookRepository, IMapper mapper) : IBookService
{
    public async Task<List<Book>> GetBooksAsync()
    {
        return await bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookAsync(int id)
    {
        Book? book= await bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Book),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Book, id)
            );
        }
        return book;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        Book? book = await bookRepository.GetByIdAsync(id);
        if (book is null)
        {

            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Book),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Book, id)
            );
        }

        bool result  = await bookRepository.DeleteByIdAsync(id);
        if (!result)
        {
            
            throw new ApiException(
                string.Format(ErrorMessages.DeleteFailed.Title, ErrorMessages.Entities.Book),
                400,
                string.Format(ErrorMessages.DeleteFailed.Detail, ErrorMessages.Entities.Book, id)
            );
        }

        return result;
    }

    public async  Task<bool> UpdateBookAsync(int id, UpdateBookDto model)
    {
        Book? book = await bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Book),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Book, id)
            );
        }

        mapper.Map(model, book);
        bool result = await bookRepository.UpdateAsync(id, book);
        if (!result)
        {

            throw new ApiException(
                string.Format(ErrorMessages.UpdateFailed.Title, ErrorMessages.Entities.Book),
                400,
                string.Format(ErrorMessages.UpdateFailed.Detail, ErrorMessages.Entities.Book, id)
            );
        }
        return result;
    }

    public async Task<bool> CreateBookAsync(CreateBookDto model)
    {
        Book? book = mapper.Map<Book>(model);
        bool result  = await bookRepository.CreateAsync(book);
        if (!result)
        {
       
            throw new ApiException(
                string.Format(ErrorMessages.CreateFailed.Title, ErrorMessages.Entities.Book),
                400,
                string.Format(ErrorMessages.CreateFailed.Detail, ErrorMessages.Entities.Book)
            );
        }
        return result;
    }
}