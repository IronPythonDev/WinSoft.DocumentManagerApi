using AutoMapper;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.Core.Presentation.DTOProfiles
{

    public class DocumentDirectoryProfile : Profile
    {
        public DocumentDirectoryProfile()
        {
            CreateMap<DocumentDirectory, DocumentDirectoryDTO>();
            CreateMap<DocumentDirectoryDTO, DocumentDirectory>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
