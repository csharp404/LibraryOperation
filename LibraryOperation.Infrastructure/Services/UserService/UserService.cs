
using AutoMapper;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.Exception;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Constants;
using LibraryOperation.Infrastructure.Helper;
using LibraryOperation.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LibraryOperation.Infrastructure.Services.UserService;

public class UserService(IRepository<User> userRepository, IMapper mapper, IPasswordHasher<User> hasher, IHttpContextAccessor accessor) : IUserService
{
    public async Task<User> GetByIdAsync(int id)
    {
        User? user = await userRepository.GetByIdAsync(id);
        if (user is null)
        {
            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, ErrorMessages.Entities.User),
                404,
                string.Format(ErrorMessages.NotFound.Detail, ErrorMessages.Entities.User, id)
            );
        }
        return user;
    }

    public async Task<bool> RegisterAsync(CreateProfileDto model)
    {
       
        var usr =await userRepository.FindByEmailAsync(x => x.Email == model.Email);
        if (usr is null)
        {
            User user = mapper.Map<User>(model);
            user.Password = hasher.HashPassword(user, model.Password);
            bool result = await userRepository.CreateAsync(user);
            return result;
        }
        throw new ApiException(string.Format(ErrorMessages.CreateFailed.Title,ErrorMessages.Entities.User), 400, string.Format(ErrorMessages.CreateFailed.Detail, ErrorMessages.Entities.User));

    }

    public async Task<bool> UpdateProfileAsync(int id, UpdateProfileDto model)
    {
        User? user = await userRepository.GetByIdAsync(id);
        if (user is null)
        {

            throw new ApiException(
                string.Format(ErrorMessages.NotFound.Title, "User"),
                404,
                string.Format(ErrorMessages.NotFound.Detail, "User", id)
            );

        }
        user.Password = hasher.HashPassword(user, model.Password);
        user.Role = UserClaimsHelper.GetRole(accessor);
        var verification = hasher.VerifyHashedPassword(user, user.Password, model.Password);
        if (verification == PasswordVerificationResult.Success)
        {
            mapper.Map(model, user);
            bool result = await userRepository.UpdateAsync(id, user);
            return result;
        }

        throw new ApiException(string.Format(ErrorMessages.UpdateFailed.Title,"User"), 400, string.Format(ErrorMessages.UpdateFailed.Detail, "User",id));
    }
}
