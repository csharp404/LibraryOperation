using Carter;
using LibraryOperation.Application.Dtos.Authentication;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Services.UserService;
using LibraryOperation.Presentation.Constants;
using LibraryOperation.Presentation.Model;

namespace LibraryOperation.Presentation.Api;

public class UserApi : ICarterModule
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
        return Results.Ok( new ApiResponse<UserApi>( success: result,data:null , message :string.Format(ApiMessages.Template.Created , ApiMessages.Entities.User)));
        

    }
    public async Task<IResult> GetUserById(int id, IUserService userService)
    {
        User user = await userService.GetByIdAsync(id);
        
            return Results.Ok(new ApiResponse<User>(true, data:user,
                string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.User)));
        
    }
    public async Task<IResult> UpdateProfile(int id, UpdateProfileDto model, IUserService userService)
    {

        bool result = await userService.UpdateProfileAsync(id, model);
        return Results.Ok(new ApiResponse<User>(true, data: null,
                string.Format(ApiMessages.Template.Updated, ApiMessages.Entities.User)));

    }
}