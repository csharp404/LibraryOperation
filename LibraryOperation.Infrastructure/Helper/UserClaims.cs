using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LibraryOperation.Infrastructure.Helper
{
    public static class UserClaimsHelper
    {
        public static int GetUserId(IHttpContextAccessor accessor)
        {
            var userIdClaim = accessor.HttpContext?.User?.Claims
                .FirstOrDefault(x => x.Type == "Id");

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return 0;
        }
        public static string GetRole(IHttpContextAccessor accessor)
        {
            var userIdClaim = accessor.HttpContext?.User?.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value.ToString();

            

            return userIdClaim;
        }
    }
}