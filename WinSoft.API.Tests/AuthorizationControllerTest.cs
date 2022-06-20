using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WinSoft.API.Controllers;
using WinSoft.API.Responses;
using WinSoft.Core.Data;
using WinSoft.Core.Infrastructure.Services;

namespace WinSoft.API.Tests
{
    public class AuthorizationControllerTest
    {
        [Fact]
        public async Task GetTokenTest()
        {
            var inMemoryConfiguration = new Dictionary<string, string> 
            {
                {"JWT:Key", "ixixkpddjaqwuwzlmdncorjzmltezdiozwvcouqxaeqygtbvzijpslwmxjxomnhogivlnqrchhznrhcehwmplwerokgxizwnswrmjytsmbbhurshzhvbmpojsoogkaly"},
                {"JWT:Issuer", "1111"},
                {"JWT:Audience", "1111"},
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemoryConfiguration).Build();

            var applicatioContext = new ApplicationContext("GetTokenTestDB");
            var userService = new UserService(applicatioContext);

            var email = "test@gmail.com";
            var password = "password";

            await userService.CreateUser(email, password);

            var authorizationService = new AuthorizationService(userService, configuration);
            var controller = new AuthorizationController(new LoggerFactory().CreateLogger<AuthorizationController>(), authorizationService, userService);

            var token = await controller.GetToken(new AuthorizationModel { Email = email, Password = password });

            Assert.True((token is OkObjectResult result) && (result.Value is AuthorizationResponse response) && (response.Email == email));
        }

        [Fact]
        public async Task GetTokenIfUserNotCreatedTest()
        {
            var inMemoryConfiguration = new Dictionary<string, string>
            {
                {"JWT:Key", "ixixkpddjaqwuwzlmdncorjzmltezdiozwvcouqxaeqygtbvzijpslwmxjxomnhogivlnqrchhznrhcehwmplwerokgxizwnswrmjytsmbbhurshzhvbmpojsoogkaly"},
                {"JWT:Issuer", "1111"},
                {"JWT:Audience", "1111"},
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemoryConfiguration).Build();

            var applicatioContext = new ApplicationContext("GetTokenIfUserNotCreatedTestDB");
            var userService = new UserService(applicatioContext);

            var email = "test@gmail.com";
            var password = "password";

            var authorizationService = new AuthorizationService(userService, configuration);
            var controller = new AuthorizationController(new LoggerFactory().CreateLogger<AuthorizationController>(), authorizationService, userService);

            var token = await controller.GetToken(new AuthorizationModel { Email = email, Password = password });

            Assert.True(token is BadRequestObjectResult result && result.Value is ErrorResponse response && response.Message == "User not found");
        }
    }
}