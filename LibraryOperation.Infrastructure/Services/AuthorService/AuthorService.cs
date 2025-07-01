using AutoMapper;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.AuthorService;

public class AuthorService (IRepository<Author> authorRepository, IMapper mapper) : IAuthorService
{
    public async Task<List<Author?>> GetAuthorsAsync()
    {
        return await authorRepository.GetAllAsync();
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        Author? author = await authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            throw new KeyNotFoundException("a user is not found");
        }
        return author;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        bool result = await authorRepository.DeleteByIdAsync(id);
        return result;
    }

    public async Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto model)
    {
        Author author = await authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            return false;
        }

        mapper.Map(model, author);
        bool result = await authorRepository.UpdateAsync(id, author);
        return result;
    }



    public async Task<bool> CreateAuthorAsync(CreateAuthorDto model)
    {
        Author author = mapper.Map<Author>(model);
        bool result = await authorRepository.CreateAsync(author);
        return result;
    }
}