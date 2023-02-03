using AutoMapper;
using OEleitor.Application.Commands.EleitorModelo.Responses;
using OEleitor.Domain.Entities;

namespace Backoffice.Infra.IOC.AutoMapperProfiles;

public class BairroProfile : Profile
{
    public BairroProfile()
    {
        CreateMap<Bairro, BairroResponse>().ReverseMap();
    }
}