using WinSoft.Core.Domain.Entitites;

namespace WinSoft.Core.Infrastructure.Services.Abstractions
{
    public interface IUserService
    {
        Task<User> GetUserByCreditails(string email, string password);
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(string email, string password);
    }
}
