using Carter;
using LibraryOperation.Application.Dtos.Authentication;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.IService;
using LibraryOperation.Infrastructure.Services.UserService;

namespace LibraryOperation.Presentation.Api;

public class User : ICarterModule
{


    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api").RequireRateLimiting("fixed");
        group.MapGet("users/{id:int}", GetUserById).RequireAuthorization(policy => policy.RequireRole("Admin"));
        group.MapPost("users", Register);
        group.MapPut("users/{id:int}", UpdateProfile).RequireAuthorization(policy => policy.RequireRole("Admin"));
    }

    public async Task<IResult> Register(CreateProfileDto model, IUserService userService)
    {
        bool result =await userService.RegisterAsync(model);
        return Results.Ok(result);
    }
    public async Task<IResult> GetUserById(int id, IUserService userService)
    {
        var result = await userService.GetByIdAsync(id);
        return Results.Ok(result);
    }
    public async Task<IResult> UpdateProfile(int id, UpdateProfileDto model, IUserService userService)
    {

        bool result = await userService.UpdateProfileAsync(id, model);
        return Results.Ok(result);
    }
}