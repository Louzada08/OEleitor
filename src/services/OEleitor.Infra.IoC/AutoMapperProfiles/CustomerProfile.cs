using AutoMapper;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Domain.Entities;

namespace Backoffice.Infra.IOC.AutoMapperProfiles;

public class EleitorProfile : Profile
{
    public EleitorProfile()
    {
        CreateMap<Eleitor, AdicionarEleitorCommand>()
            .ForMember(x => x.Email, r => r.MapFrom(r => r.Email))
            .ReverseMap();
        
        //CreateMap<Eleitor, CustomerCompactDTO>().ReverseMap();

        //CreateMap<Eleitor, PatchCustomerRequest>()
        //    .ForMember(x => x.CpfCnpj, r => r.MapFrom(r => r.CpfCnpj))
        //    .ReverseMap();
    }
}