
using Carter;
using LibraryOperation.Application.Dtos.Authentication;
using LibraryOperation.Application.IService;
using LibraryOperation.Infrastructure.Data;
using LibraryOperation.Infrastructure.Services.AuthenticationService;

namespace LibraryOperation.Presentation.Api;

public class Authentication : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("login", Login);
    }

    public  async Task<IResult> Login(LoginDto model , IAuthenticationService authenticationService)
    {
        string token = await authenticationService.Login(model);
        return Results.Ok(token);
    }
}