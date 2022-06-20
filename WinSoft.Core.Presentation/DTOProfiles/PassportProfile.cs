using AutoMapper;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.Core.Presentation.DTOProfiles
{
    public class PassportProfile : Profile
    {
        public PassportProfile()
        {
            CreateMap<Passport, PassportDTO>();
            CreateMap<PassportDTO, Passport>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreatePassportDTO, Passport>();

        }
    }
}
