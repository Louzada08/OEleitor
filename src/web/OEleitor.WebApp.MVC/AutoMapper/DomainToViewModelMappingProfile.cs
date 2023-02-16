using AutoMapper;
using OEleitor.WebApp.MVC.Dtos;
using OEleitor.WebApp.MVC.Models;

namespace OEleitor.WebApp.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BairroViewModel, BairroDTO>()
              .ReverseMap();

            CreateMap<EleitorViewModel, EleitorDTO>()
              .ReverseMap();

            CreateMap<UsuarioRegistro, UsuarioDTO>()
              .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
              .ForMember(d => d.Nome, o => o.MapFrom(s => s.Nome))
              .ForMember(d => d.Funcao, o => o.MapFrom(s => s.Funcao.ToString()))
              .ForMember(d => d.Senha, o => o.MapFrom(s => s.Senha))
              .ForMember(d => d.SenhaConfirmacao, o => o.MapFrom(s => s.SenhaConfirmacao))
              .ReverseMap();
        }
    }

}
