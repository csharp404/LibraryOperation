using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.IService;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<bool> RegisterAsync(CreateProfileDto model);
    Task<bool> UpdateProfileAsync(int id,UpdateProfileDto model);
}