
using Carter;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Services.LoanService;
using LibraryOperation.Presentation.Constants;
using LibraryOperation.Presentation.Model;

namespace LibraryOperation.Presentation.Api
{
    public class LoanApi :ICarterModule
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
            List<Loan?> result = await loanService.GetLoansAsync();
            if (result !=null)
            {
                return Results.Ok(new ApiResponse<List<Loan>>(true, data: result,
                    string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Loan)));
            }

            return Results.Ok(new ApiResponse<List<Loan>>(false, data: null,
                string.Format(ApiMessages.Template.RetrieveFailed, ApiMessages.Entities.Loan)));

        }
        public async Task<IResult> CreateNewLoans( CreateLoanDto model, ILoanService loanService)
        {
            var result = await loanService.CreateLoanAsync(model);
            return Results.Ok(new ApiResponse<List<Loan>>(true, data: null,
                    string.Format(ApiMessages.Template.Created, ApiMessages.Entities.Loan)));

   

        }
        public async Task<IResult> UpdateLoan(int id, UpdateLoanDto model, ILoanService loanService)
        {
            var result = await loanService.UpdateLoanAsync(id,model);
          
                return Results.Ok(new ApiResponse<List<Loan>>(true, data: null,
                    string.Format(ApiMessages.Template.Created, ApiMessages.Entities.Loan)));
        }



    }
}
