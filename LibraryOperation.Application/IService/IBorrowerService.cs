using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.IService;

public interface IBorrowerService
{
    Task<List<Borrower>> GetBorrowersAsync();
    Task<Borrower> GetBorrowerAsync(int id);
    Task<bool> DeleteBorrowerAsync(int id);

    Task<bool> UpdateBorrowerAsync(int id, UpdateBorrowerDto model);
    Task<bool> CreateBorrowerAsync(CreateBorrowerDto model);
}