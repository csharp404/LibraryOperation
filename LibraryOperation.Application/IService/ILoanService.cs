using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.IService;

public interface ILoanService
{
    Task<List<Loan?>> GetLoansAsync();
    Task<bool> UpdateLoanAsync(int id, UpdateLoanDto model);
    Task<bool> CreateLoanAsync(CreateLoanDto model);
}