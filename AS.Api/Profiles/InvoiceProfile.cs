using AS.Api.Dtos;
using AutoMapper;
public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForMember
                    (
                        dest => dest.State,
                        opt => opt.MapFrom
                        (
                            src => src.State.GetDescription()
                        )
                    )
            .ReverseMap();

        CreateMap<InvoiceDetalsDto, Invoice>()
            .ForMember(dest => dest.State,
                        opt => opt.MapFrom
                        (src => src.State.GetDescription() ))
            .ForMember(x => x.customer, opt => opt.MapFrom( sec => sec.customerList))
            .ReverseMap();
    }

}
