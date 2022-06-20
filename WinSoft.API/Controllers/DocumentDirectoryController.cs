using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinSoft.API.Extensions;
using WinSoft.API.Responses;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Infrastructure.Exceptions;
using WinSoft.Core.Infrastructure.Services.Abstractions;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.API.Controllers
{
    [Route("api/directory")]
    [ApiController]
    public class DocumentDirectoryController : ControllerBase
    {
        public DocumentDirectoryController(IDocumentDirectoryService documentDirectoryService, IUserService userService, IMapper mapper, IDocumentPackageService documentPackageService)
        {
            DocumentDirectoryService=documentDirectoryService;
            UserService=userService;
            Mapper=mapper;
            DocumentPackageService=documentPackageService;
        }

        public IDocumentDirectoryService DocumentDirectoryService { get; }
        public IUserService UserService { get; }
        public IMapper Mapper { get; }
        public IDocumentPackageService DocumentPackageService { get; }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await UserService.GetUserFromClaimsPrincipal(User);

                var directories = await DocumentDirectoryService.GetAdministratorDocumentDirectories(user.Id);

                return Ok(Mapper.Map<IList<DocumentDirectoryDTO>>(directories));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse { Message = "Server error" });
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await UserService.GetUserFromClaimsPrincipal(User);

                var directory = await DocumentDirectoryService.GetAdministratorDocumentDirectory(id, user.Id);

                return Ok(Mapper.Map<DocumentDirectoryDTO>(directory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse { Message = "Server error" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post()
        {
            try
            {
                var directory = await DocumentDirectoryService.CreateDocumentDirectory();

                await DocumentDirectoryService.ChangeDocumentDirectoryAdministrator(await UserService.GetUserFromClaimsPrincipal(User), directory);

                return Created($"api/directory/{directory.Id}", Mapper.Map<DocumentDirectoryDTO>(directory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse { Message = "Server error" });
            }
        }

        [HttpPost("{directoryId}/package")]
        [Authorize]
        public async Task<IActionResult> CreatePackage([FromRoute] Guid directoryId, [FromBody] CreateDocumentsPackageDTO packageDTO)
        {
            try
            {
                var user = await UserService.GetUserFromClaimsPrincipal(User);

                var directory = await DocumentDirectoryService.GetDocumentDirectoryById(directoryId);

                var package = Mapper.Map<DocumentsPackage>(packageDTO);
                package.DirectoryId = directoryId;
                package.OwnerId = user.Id;

                package.Status = Core.Domain.Entitites.Enums.DocumentStatus.Waiting;

                package = await DocumentPackageService.CreatePackage(package);

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
