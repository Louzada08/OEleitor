using AutoMapper;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EnderecoModelo.Requests;
using OEleitor.Domain.Entities;

namespace Backoffice.Infra.IOC.AutoMapperProfiles;

public class EleitorProfile : Profile
{
    public EleitorProfile()
    {
        CreateMap<Eleitor, AdicionarEleitorCommand>()
            .ForMember(x => x.Email, r => r.MapFrom(r => r.Email)).ReverseMap();
        
        CreateMap<Dependente, AdicionarDependenteCommand>().ReverseMap();

        CreateMap<Endereco, EnderecoCommand>().ReverseMap();

        CreateMap<Bairro, BairroCommand>().ReverseMap();
    }
}