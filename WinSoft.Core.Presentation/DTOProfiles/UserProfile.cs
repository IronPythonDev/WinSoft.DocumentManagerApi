using AutoMapper;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Presentation.DTO;

namespace WinSoft.Core.Presentation.DTOProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
