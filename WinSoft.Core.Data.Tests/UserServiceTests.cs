using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Extensions;
using WinSoft.Core.Infrastructure.Services;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.Core.Data.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task CreateUserTest()
        {
            var applicationContext = new ApplicationContext("CreateUserTestDB");

            IUserService userService = new UserService(applicationContext);

            var email = "test@gmail.com";
            var password = "password";

            await userService.CreateUser(email, password);

            Assert.True(applicationContext.Users.Any(p => p.Email == "test@gmail.com" && p.Password == "password".MD5Hash()));
        }

        [Fact]
        public async Task CreateUserIsAlreadyExistsExeptionTest()
        {
            await Assert.ThrowsAsync(new EntityIsAlreadyExistsException("").GetType(), async () =>
            {
                var applicationContext = new ApplicationContext("CreateUserIsAlreadyExistsExeptionTestDB");

                IUserService userService = new UserService(applicationContext);

                var email = "test@gmail.com";
                var password = "password";

                await userService.CreateUser(email, password);
                await userService.CreateUser(email, password);
            });
        }

        [Fact]
        public async Task GetUserByCreditailsTest()
        {
            var applicationContext = new ApplicationContext("GetUserByCreditailsTestDB");

            IUserService userService = new UserService(applicationContext);

            var email = "test@gmail.com";
            var password = "password";

            await userService.CreateUser(email, password);

            Assert.NotNull(await userService.GetUserByCreditails(email, password));
        }
    }
}