using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Infrastructure.Extensions;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.Core.Infrastructure.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public AuthorizationService(IUserService userService, IConfiguration configuration)
        {
            UserService = userService;
            Configuration = configuration;
        }

        public IUserService UserService { get; }
        public IConfiguration Configuration { get; }

        public Task<ClaimsIdentity> GetUserIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            ClaimsIdentity claimsIdentity = new(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return Task.FromResult(claimsIdentity);
        }

        public async Task<string> GetUserJwt(User user)
        {
            var identity = await GetUserIdentity(user);

            var jwtConfiguration = Configuration.GetJwtConfiguration();

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: jwtConfiguration.Issuer,
                audience: jwtConfiguration.Audience,
                identity.Claims,
                expires: DateTime.Now.Add(TimeSpan.FromHours(24)),
                signingCredentials: jwtConfiguration.Key);

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
