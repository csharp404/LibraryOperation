using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.IService;

public interface IAuthorService
{
    Task<List<Author?>> GetAuthorsAsync();
    Task<Author> GetAuthorAsync(int id);
    Task<bool> DeleteAuthorAsync(int id);

    Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto model);
    Task<bool> CreateAuthorAsync(CreateAuthorDto model);
}