using AutoMapper;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.Exception;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Constants;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.AuthorService;

public class AuthorService (IRepository<Author?> authorRepository, IMapper mapper) : IAuthorService
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
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Author),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Author,id)
            );
        }
        return author;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {

        Author? author =await  authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Author),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Author, id)
            );
        }
        bool result = await authorRepository.DeleteByIdAsync(id);
        if (!result)
        {
          
            throw new ApiException(
                string.Format(ErrorMessages.DeleteFailed.Title, ErrorMessages.Entities.Author),
                400,
                string.Format(ErrorMessages.DeleteFailed.Detail, ErrorMessages.Entities.Author)
            );
        }
        return result;
    }

    public async Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto model)
    {
        Author? author = await authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Author),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Author, id)
            );
        }

        mapper.Map(model, author);
        bool result = await authorRepository.UpdateAsync(id, author);
        if (!result)
        {
           
            throw new ApiException(
                string.Format(ErrorMessages.UpdateFailed.Title, ErrorMessages.Entities.Author),
                400,
                string.Format(ErrorMessages.UpdateFailed.Detail, ErrorMessages.Entities.Author)
            );
        }
        return result;
    }



    public async Task<bool> CreateAuthorAsync(CreateAuthorDto model)
    {
        Author? author = mapper.Map<Author>(model);
        bool result = await authorRepository.CreateAsync(author);
        if (!result)
        {
    
            throw new ApiException(
                string.Format(ErrorMessages.CreateFailed.Title, ErrorMessages.Entities.Author),
                400,
                string.Format(ErrorMessages.CreateFailed.Detail, ErrorMessages.Entities.Author)
            );
        }
        return result;
    }
}