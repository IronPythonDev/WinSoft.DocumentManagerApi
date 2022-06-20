using AutoMapper;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.Core.Presentation.DTOProfiles
{
    public class DrivingLicenceProfile : Profile
    {
        public DrivingLicenceProfile()
        {
            CreateMap<DrivingLicence, DrivingLicenceDTO>();
            CreateMap<DrivingLicenceDTO, DrivingLicence>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateDrivingLicenceDTO, DrivingLicence>();

        }
    }
}
