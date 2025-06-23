using LibraryOperation.Application.Dtos.Authentication;

namespace LibraryOperation.Application.IService;

public interface IAuthenticationService
{
    Task<string> Login(LoginDto model);
}