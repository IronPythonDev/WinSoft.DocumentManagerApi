using AutoMapper;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.Core.Presentation.DTOProfiles
{
    public class DocumentsPackageProfile : Profile
    {
        public DocumentsPackageProfile()
        {
            CreateMap<DocumentsPackage, DocumentsPackageDTO>();
            CreateMap<DocumentsPackageDTO, DocumentsPackage>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.OwnerId, opt => opt.Ignore())
                .ForMember(p => p.DirectoryId, opt => opt.Ignore())
                .ForMember(p => p.PassportId, opt => opt.Ignore())
                .ForMember(p => p.DrivingLicenceId, opt => opt.Ignore())
                .ForMember(p => p.CreditCardId, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DocumentsPackage, DocumentsPackageSmallDTO>();
            CreateMap<DocumentsPackageSmallDTO, DocumentsPackage>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.OwnerId, opt => opt.Ignore())
                .ForMember(p => p.DirectoryId, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateDocumentsPackageDTO, DocumentsPackage>();

        }
    }
}
