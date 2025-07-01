using AutoMapper;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.LoanService;

public class LoanService(IRepository<Loan> loanRepository, IMapper mapper): ILoanService
{
    


    public async Task<List<Loan?>> GetLoansAsync()
    {
        return await loanRepository.GetAllAsync();
    }


    public async Task<bool> UpdateLoanAsync(int id, UpdateLoanDto model)
    {

        Loan loan= await loanRepository.GetByIdAsync(id);
        if (loan is null)
        {
            return false;
        }

        mapper.Map(model, loan);
        bool result = await loanRepository.UpdateAsync(id, loan);
        return result;
    }

    public async Task<bool> CreateLoanAsync(CreateLoanDto model)
    {
        Loan loan = mapper.Map<Loan>(model);
        bool result = await loanRepository.CreateAsync(loan);
        return result;
    }

    
}