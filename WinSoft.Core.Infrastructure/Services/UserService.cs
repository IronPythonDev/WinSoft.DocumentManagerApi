using Microsoft.EntityFrameworkCore;
using WinSoft.Core.Data;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Extensions;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.Core.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public UserService(ApplicationContext applicationContext)
        {
            ApplicationContext=applicationContext;
        }

        public ApplicationContext ApplicationContext { get; }

        public async Task<User> CreateUser(string email, string password)
        {
            try
            {
                await GetUserByCreditails(email, password);

                throw new EntityIsAlreadyExistsException("User is already exists");
            }
            catch (NotFoundException)
            {
                var user = (await ApplicationContext.Users.AddAsync(new User { Email = email, Password = password.MD5Hash() })).Entity;

                await ApplicationContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<User> GetUserByCreditails(string email, string passoword)
        {
            try
            {
                return await ApplicationContext.Users.FirstAsync(p => p.Email == email && p.Password == passoword.MD5Hash());
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("User not found");
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await ApplicationContext.Users.FirstAsync(p => p.Email == email);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException("User not found");
            }
        }
    }
}
