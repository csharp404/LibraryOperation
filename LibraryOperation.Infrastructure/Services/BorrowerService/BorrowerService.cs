using AutoMapper;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.Exception;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Constants;
using LibraryOperation.Infrastructure.Helper;
using Microsoft.AspNetCore.Http;

namespace LibraryOperation.Infrastructure.Services.BorrowerService;

public class BorrowerService (IRepository<Borrower> borrowerRepository, IMapper mapper,IHttpContextAccessor accessor) : IBorrowerService
{
    public async Task<List<Borrower>> GetBorrowersAsync()
    {


        return await borrowerRepository.GetAllAsync();
    }


    public async Task<Borrower> GetBorrowerAsync(int id)
    {
        Borrower? borrower = await borrowerRepository.GetByIdAsync(id);
        if (borrower is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Borrower),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Borrower, id)
            );
        }
        return borrower;
    }

    public async Task<bool> DeleteBorrowerAsync(int id)
    {

        Borrower? borrower =await  borrowerRepository.GetByIdAsync(id);
        if (borrower == null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Borrower),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Borrower, id)
            );
     
        }
        bool result = await borrowerRepository.DeleteByIdAsync(id);
        if (!result)
        {
 
            throw new ApiException(
                string.Format(ErrorMessages.DeleteFailed.Title, ErrorMessages.Entities.Borrower),
                400,
                string.Format(ErrorMessages.DeleteFailed.Detail, ErrorMessages.Entities.Borrower, id)
            );
        }
        return result;
    }

    public async Task<bool> UpdateBorrowerAsync(int id, UpdateBorrowerDto model)
    {
        Borrower? borrower = await borrowerRepository.GetByIdAsync(id);

        if (borrower is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.Borrower),
                400,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.Borrower, id)
            );
        }
        int userId = UserClaimsHelper.GetUserId(accessor);
        if (userId == null)
        {
            throw new ApiException(ErrorMessages.Credential.Title, 404, ErrorMessages.Credential.Detail);
        }
        model.UserId = userId;
        mapper.Map(model, borrower);
        bool result = await borrowerRepository.UpdateAsync(id, borrower);
        if (!result)
        {
            throw new ApiException(
                string.Format(ErrorMessages.UpdateFailed.Title, ErrorMessages.Entities.Borrower),
                400,
                string.Format(ErrorMessages.UpdateFailed.Detail, ErrorMessages.Entities.Borrower, id)
            );
        }
        return result;
        
    }

    public async Task<bool> CreateBorrowerAsync(CreateBorrowerDto model)
    {
        var userIdClaim = accessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "Id");

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new ApiException(ErrorMessages.Credential.Title, 401, ErrorMessages.Credential.Detail);
        }

        Borrower borrower = mapper.Map<Borrower>(model);
        borrower.UserId = userId;
        bool result = await borrowerRepository.CreateAsync(borrower);
        if (!result)
        {
            
            throw new ApiException(
                string.Format(ErrorMessages.CreateFailed.Title, ErrorMessages.Entities.Borrower),
                400,
                string.Format(ErrorMessages.CreateFailed.Detail, ErrorMessages.Entities.Borrower)
            );
        }
        return result;
    }

}