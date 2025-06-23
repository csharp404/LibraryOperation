
using Carter;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.IService;
using LibraryOperation.Infrastructure.Services.LoanService;

namespace LibraryOperation.Presentation.Api
{
    public class Loan :ICarterModule
    {
   

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api").RequireRateLimiting("fixed");
            group.MapGet("loans",GetAllLoans).RequireAuthorization(policy => policy.RequireRole("Admin"));
            group.MapPost("loans",CreateNewLoans).RequireAuthorization(policy=>policy.RequireRole("Admin"));
            group.MapPut("loans/{id:int}",UpdateLoan).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        }
        public async Task<IResult> GetAllLoans(ILoanService loanService)
        {
            var result = await loanService.GetLoansAsync();
            return Results.Ok(result);
        }
        public async Task<IResult> CreateNewLoans( CreateLoanDto model, ILoanService loanService)
        {
            var result = await loanService.CreateLoanAsync(model);
            return Results.Ok(result);
        }
        public async Task<IResult> UpdateLoan(int id, UpdateLoanDto model, ILoanService loanService)
        {
            var result = await loanService.GetLoansAsync();
            return Results.Ok(result);
        }



    }
}
