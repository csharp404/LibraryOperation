
using Carter;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Services.BorrowerService;
using LibraryOperation.Presentation.Constants;
using LibraryOperation.Presentation.Model;

namespace LibraryOperation.Presentation.Api
{
    public class BorrowerApi : ICarterModule
    {




        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api").RequireRateLimiting("fixed");

            group.MapGet("borrowers", GetAllBorrowers).RequireAuthorization(policy => policy.RequireRole("Admin"));
            group.MapGet("borrowers/{id:int}", GetBorrowerById).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapPost("borrowers", AddNewBorrower).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapPut("borrowers/{id:int}", UpdateBorrower).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapDelete("borrowers/{id:int}", DeleteBorrower).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        }
        public async Task<IResult> DeleteBorrower(int id, IBorrowerService borrowerService)
        {
            var result = await borrowerService.DeleteBorrowerAsync(id);
            return Results.Ok(new ApiResponse<User>(true, data: null,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Borrower)));
        }
        public async Task<IResult> UpdateBorrower(int id, UpdateBorrowerDto model, IBorrowerService borrowerService)
        {
            var result = await borrowerService.UpdateBorrowerAsync(id, model);
            return Results.Ok(new ApiResponse<User>(true, data: null,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Borrower)));
        }
        public async Task<IResult> GetAllBorrowers(IBorrowerService borrowerService)
        {
            List<Borrower> result = await borrowerService.GetBorrowersAsync();
            return Results.Ok(new ApiResponse<List<Borrower>>(true, data: result,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Borrower)));
        }

        public async Task<IResult> GetBorrowerById(int id, IBorrowerService borrowerService)
        {
            var result = await borrowerService.GetBorrowerAsync(id);
            return Results.Ok(new ApiResponse<Borrower>(true, data: result,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Borrower)));
        }
        public async Task<IResult> AddNewBorrower(CreateBorrowerDto model, IBorrowerService borrowerService)
        {

            var result = await borrowerService.CreateBorrowerAsync(model);
            return Results.Ok(new ApiResponse<Borrower>(true, data: null,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Borrower)));
        }





    }
}