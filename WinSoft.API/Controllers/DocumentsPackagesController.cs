using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinSoft.API.Extensions;
using WinSoft.API.Responses;
using WinSoft.Core.Domain.Entitites.Enums;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Services.Abstractions;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.API.Controllers
{
    [Route("api/package")]
    [ApiController]
    [Authorize]
    public class DocumentsPackagesController : ControllerBase
    {
        public DocumentsPackagesController(IUserService userService, IDocumentPackageService documentPackageService, IMapper mapper)
        {
            UserService=userService;
            DocumentPackageService=documentPackageService;
            Mapper=mapper;
        }

        public IUserService UserService { get; }
        public IDocumentPackageService DocumentPackageService { get; }
        public IMapper Mapper { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            try
            {
                var user = await UserService.GetUserFromClaimsPrincipal(User);

                var package = user.Role == UserRole.Administrator ? await DocumentPackageService.GetPackageById(id) : await DocumentPackageService.GetUserPackageById(user.Id, id);

                return Ok(Mapper.Map<DocumentsPackageDTO>(package));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{packageId}")]
        public async Task<IActionResult> UpdatePackage([FromRoute] Guid packageId, [FromBody] DocumentsPackageDTO packageDTO)
        {
            try
            {
                var user = await UserService.GetUserFromClaimsPrincipal(User);

                var package = await DocumentPackageService.GetPackageById(packageId);

                if (!(user.Role != UserRole.Administrator) && (package.Status == DocumentStatus.Waiting && packageDTO.Status == DocumentStatus.Verified.ToString()) && !(await DocumentPackageService.CanVerifyPackage(packageId)))
                    return BadRequest(new ErrorResponse { Message = "You can't verify this package!" });

                package = Mapper.Map(packageDTO, package);

                await DocumentPackageService.FullUpdatePackage(package);

                return Ok(Mapper.Map<DocumentsPackageDTO>(package));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
