using System.Security.Claims;
using WinSoft.Core.Domain.Entitites;

namespace WinSoft.Core.Infrastructure.Services.Abstractions
{
    public interface IAuthorizationService
    {
        Task<string> GetUserJwt(User user);
        Task<ClaimsIdentity> GetUserIdentity(User user);
    }
}
