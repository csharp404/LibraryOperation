using Carter;
using LibraryOperation.Application.IRepository;
using LibraryOperation.Application.IService;
using LibraryOperation.Application.Mapper;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Data;
using LibraryOperation.Infrastructure.Repository;
using LibraryOperation.Infrastructure.Services.AuthenticationService;
using LibraryOperation.Infrastructure.Services.AuthorService;
using LibraryOperation.Infrastructure.Services.BookService;
using LibraryOperation.Infrastructure.Services.BorrowerService;
using LibraryOperation.Infrastructure.Services.LoanService;
using LibraryOperation.Infrastructure.Services.UserService;
using LibraryOperation.Presentation.Exception_MiddleWare;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(op =>
{
    op.RequireHttpsMetadata = false;
    op.SaveToken = true;
    op.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["jwt"]!))
    };
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddDbContext<MyDbContext>(op =>
    op.UseNpgsql(builder.Configuration.GetConnectionString("DBCS")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IBorrowerService,BorrowerService>();
builder.Services.AddScoped<ILoanService,LoanService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
//app.MapPost("login", async (LoginDto model, IAuthenticationService service) =>
//{
//    string token = await service.Login(model);
//    return Results.Ok(token);
//});
app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.MapCarter();
app.Run();
