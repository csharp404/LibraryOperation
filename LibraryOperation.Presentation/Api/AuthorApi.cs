
using Carter;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Services.AuthorService;
using LibraryOperation.Presentation.Constants;
using LibraryOperation.Presentation.Model;

namespace LibraryOperation.Presentation.Api
{
    public class AuthorApi : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api").RequireRateLimiting("fixed");

            group.MapGet("authors", GetAllAuthors).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapGet("authors/{id:int}", GetAnAuthorById).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapPost("authors", AddNewAuthor).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapPut("authors/{id:int}", UpdateAnAuthor).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapDelete("authors/{id:int}", DeleteAnAuthor).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        }

        public async Task<IResult> DeleteAnAuthor(int id, IAuthorService authorService)
        {
            bool result = await authorService.DeleteAuthorAsync(id);
            return Results.Ok(new ApiResponse<List<AuthorApi>>(true, data: null,
                string.Format(ApiMessages.Template.Deleted, ApiMessages.Entities.Author)));
        }
        public async Task<IResult> UpdateAnAuthor(int id, UpdateAuthorDto model, IAuthorService authorService)
        {
            bool result = await authorService.UpdateAuthorAsync(id,model);
            return Results.Ok(result);
        }
        public async Task<IResult> AddNewAuthor(CreateAuthorDto model, IAuthorService authorService)
        {
            bool result = await authorService.CreateAuthorAsync(model);
            return Results.Ok(new ApiResponse<List<AuthorApi>>(true, data: null,
                string.Format(ApiMessages.Template.Created, ApiMessages.Entities.Author)));
        }
        public async Task<IResult> GetAnAuthorById(int id,IAuthorService authorService)
        {
            var result = await authorService.GetAuthorAsync(id);
            return Results.Ok(new ApiResponse<Author>(true, data: result,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Author)));
        }
        public async Task<IResult> GetAllAuthors( IAuthorService authorService)
        {
            var result = await authorService.GetAuthorsAsync();
            return Results.Ok(new ApiResponse<List<Author>>(true, data: result,
                string.Format(ApiMessages.Template.Deleted, ApiMessages.Entities.Author)));
        }

    }
}