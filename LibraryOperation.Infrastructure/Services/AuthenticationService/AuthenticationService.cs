using System.ComponentModel.DataAnnotations;
using LibraryOperation.Application.Dtos.Authentication;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Data;
using LibraryOperation.Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryOperation.Infrastructure.Services.AuthenticationService;

public class AuthenticationService(MyDbContext db, IConfiguration configuration, IPasswordHasher<User> hasher):IAuthenticationService
   
{
   
    public async Task<string> Login(LoginDto model)
    {
        User user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (user != null)
        {
            var result = hasher.VerifyHashedPassword(user, user.Password, model.Password);
            if (result == PasswordVerificationResult.Success)
            {
                string secretKey = configuration.GetSection("jwt").Value;
                if (secretKey != null)
                    return JWTHelper.GenerateToken(model.Email, user.Role, user.Id, secretKey, 60);
            }
        }

        throw new ValidationException("you have error in your credentials");
    
    }


}