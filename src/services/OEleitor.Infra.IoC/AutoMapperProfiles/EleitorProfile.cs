using AutoMapper;
using OEleitor.Application.Commands.EleitorModelo.Requests;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Application.Commands.EnderecoModelo.Requests;
using OEleitor.Domain.Dtos;
using OEleitor.Domain.Entities;
using System.Linq;

namespace Backoffice.Infra.IOC.AutoMapperProfiles;

public class EleitorProfile : Profile
{
    public EleitorProfile()
    {
        CreateMap<Eleitor, AdicionarEleitorCommand>()
            .ForMember(x => x.Email, r => r.MapFrom(r => r.Email)).ReverseMap();
        CreateMap<Eleitor, EleitorResponse>()
            .ForPath(x => x.BairroDto, r => r.MapFrom(r => r.Bairro))
            .ForPath(x => x.FoneDto.Fone1, r => r.MapFrom(r => r.Fone.Fone1))
            .ForPath(x => x.FoneDto.Fone1TemWhatsapp, r => r.MapFrom(r => r.Fone.Fone1TemWhatsapp))
            .ForPath(x => x.FoneDto.Fone2, r => r.MapFrom(r => r.Fone.Fone2))
            .ForPath(x => x.FoneDto.Fone2TemWhatsapp, r => r.MapFrom(r => r.Fone.Fone2TemWhatsapp))
            .ForPath(x => x.EnderecoDto.Logradouro, r => r.MapFrom(r => r.Endereco.Logradouro))
            .ForPath(x => x.EnderecoDto.Complemento, r => r.MapFrom(r => r.Endereco.Complemento))
            .ForPath(x => x.EnderecoDto.Numero, r => r.MapFrom(r => r.Endereco.Numero))
            .ForPath(x => x.EnderecoDto.Estado, r => r.MapFrom(r => r.Endereco.Estado))
            .ForPath(x => x.EnderecoDto.Cep, r => r.MapFrom(r => r.Endereco.Cep))
            .ForPath(x => x.EnderecoDto.Cidade, r => r.MapFrom(r => r.Endereco.Cidade))
            .ForPath(x => x.DependentesDto, r => r.MapFrom(r => r.Dependentes))
            .ReverseMap();

        CreateMap<Dependente, AdicionarDependenteCommand>().ReverseMap();

        CreateMap<Bairro, BairroCommand>().ReverseMap();
        CreateMap<Bairro, BairroDto>().ReverseMap();
        CreateMap<Dependente, DependenteDto>().ReverseMap();
    }
}