using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using WinSoft.API.Responses;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Services.Abstractions;

namespace WinSoft.API.Controllers
{
    public class AuthorizationModel
    {
        [JsonPropertyName("email"), NotNull] public string Email { get; set; } 
        [JsonPropertyName("password"), NotNull] public string Password { get; set; }
    }
    public class AuthorizationResponse
    {
        [JsonPropertyName("email"), NotNull] public string Email { get; set; }
        [JsonPropertyName("access_token")] public string AccessToken { get; set; }
    }


    [ApiController]
    [Route("api/authorization")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly Core.Infrastructure.Services.Abstractions.IAuthorizationService authorizationService;
        private readonly IUserService userService;

        public AuthorizationController(
            ILogger<AuthorizationController> logger,
            Core.Infrastructure.Services.Abstractions.IAuthorizationService authorizationService, 
            IUserService userService)
        {
            _logger = logger;
            this.authorizationService=authorizationService;
            this.userService=userService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "token")]
        public async Task<IActionResult> GetToken([FromBody] AuthorizationModel authorization)
        {
            try
            {
                var user = await userService.GetUserByCreditails(authorization.Email, authorization.Password);

                var token = await authorizationService.GetUserJwt(user);

                return Ok(new AuthorizationResponse { AccessToken = token, Email = user.Email });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}