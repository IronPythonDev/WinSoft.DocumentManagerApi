using Microsoft.Extensions.Configuration;
using System.Text;

namespace WinSoft.Core.Infrastructure.Extensions
{
    public class JwtConfiguration
    {
        public Microsoft.IdentityModel.Tokens.SigningCredentials Key { get; set; }
        public Microsoft.IdentityModel.Tokens.SymmetricSecurityKey SymmetricSecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }

    public static class ConfigurationExtensions
    {
        public static JwtConfiguration GetJwtConfiguration(this IConfiguration configuration) =>
            new()
            {
                SymmetricSecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Key"])),
                Key = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Key"])), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256),
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"],
            };
    }
}
