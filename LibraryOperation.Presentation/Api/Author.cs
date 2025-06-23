
using Carter;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.IService;
using LibraryOperation.Infrastructure.Services.AuthorService;

namespace LibraryOperation.Presentation.Api
{
    public class Author : ICarterModule
    {

        
     
       
        //    DELETE /api/authors/{id}: Delete an author.

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
            return Results.Ok(result);
        }
        public async Task<IResult> UpdateAnAuthor(int id, UpdateAuthorDto model, IAuthorService authorService)
        {
            bool result = await authorService.UpdateAuthorAsync(id,model);
            return Results.Ok(result);
        }
        public async Task<IResult> AddNewAuthor(CreateAuthorDto model, IAuthorService authorService)
        {
            bool result = await authorService.CreateAuthorAsync(model);
            return Results.Ok(result);
        }
        public async Task<IResult> GetAnAuthorById(int id,IAuthorService authorService)
        {
            var result = await authorService.GetAuthorAsync(id);
            return Results.Ok(result);
        }
        public async Task<IResult> GetAllAuthors( IAuthorService authorService)
        {
            var result = await authorService.GetAuthorsAsync();
            return Results.Ok(result);
        }

    }
}