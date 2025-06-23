using AutoMapper;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;

using Microsoft.AspNetCore.Http;

namespace LibraryOperation.Infrastructure.Services.BorrowerService;

public class BorrowerService (IRepository<Borrower> borrowerRepository, IMapper mapper,IHttpContextAccessor accessor) : IBorrowerService
{
    public async Task<List<Borrower?>> GetBorrowersAsync()
    {
        return await borrowerRepository.GetAllAsync();
    }


    public async Task<Borrower> GetBorrowerAsync(int id)
    {
        Borrower? borrower = await borrowerRepository.GetByIdAsync(id);
        if (borrower is null)
        {
            throw new KeyNotFoundException("a user is not found");
        }
        return borrower;
    }

    public async Task<bool> DeleteBorrowerAsync(int id)
    {
        bool result = await borrowerRepository.DeleteByIdAsync(id);
        return result;
    }

    public async Task<bool> UpdateBorrowerAsync(int id, UpdateBorrowerDto model)
    {
        Borrower borrower = mapper.Map<Borrower>(model);
        bool result = await borrowerRepository.UpdateAsync(id, borrower);
        return result;
    }

    public async Task<bool> CreateBorrowerAsync(CreateBorrowerDto model)
    {
        var userIdClaim = accessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "Id");

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            return false; 
        }

        Borrower borrower = mapper.Map<Borrower>(model);
        borrower.UserId = userId;
        bool result = await borrowerRepository.CreateAsync(borrower);
        return result;
    }

}