using System.Security.Claims;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.API.Extensions
{
    public static class UserServiceExtensions
    {
        public static async Task<User> GetUserFromClaimsPrincipal(this IUserService service, ClaimsPrincipal claimtPrincipal) =>
            await service.GetUserByEmail(claimtPrincipal.Identity.Name);
    }
}
