using AutoMapper;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;
using WinSoft.Core.Presentation.DTO.Documents;

namespace WinSoft.Core.Presentation.DTOProfiles
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, CreditCardDTO>();
            CreateMap<CreditCardDTO, CreditCard>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCreditCardDTO, CreditCard>();
        }
    }
}
