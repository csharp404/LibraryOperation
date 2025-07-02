using AutoMapper;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.Exception;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Constants;
using LibraryOperation.Infrastructure.Repository;

namespace LibraryOperation.Infrastructure.Services.LoanService;

public class LoanService(IRepository<Loan?> loanRepository, IMapper mapper): ILoanService
{
    


    public async Task<List<Loan?>> GetLoansAsync()
    {
     return  await loanRepository.GetAllAsync();
    }


    public async Task<bool> UpdateLoanAsync(int id, UpdateLoanDto model)
    {

        Loan? loan= await loanRepository.GetByIdAsync(id);
        if (loan is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Loan),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Loan, id)
            );
        }

        mapper.Map(model, loan);
        bool result = await loanRepository.UpdateAsync(id, loan);
        if (!result)
        {
            throw new ApiException(string.Format(ErrorMessages.UpdateFailed.Title,ErrorMessages.Entities.Loan), 400, string.Format(ErrorMessages.UpdateFailed.Detail,ErrorMessages.Entities.Loan,id));
        }
        return result;
    }

    public async Task<bool> CreateLoanAsync(CreateLoanDto model)
    {
        Loan? loan = mapper.Map<Loan>(model);
        bool result = await loanRepository.CreateAsync(loan);
        if (!result)
        {
            
            throw new ApiException(string.Format(ErrorMessages.CreateFailed.Title,ErrorMessages.Entities.Loan), 400, string.Format(ErrorMessages.CreateFailed.Detail,ErrorMessages.Entities.Loan));
        }
        return result;
    }

    
}