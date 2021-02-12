using AutoMapper;
using Core;
using IdrugWeb.Models;

namespace IdrugWeb.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioModel, Usuario>().ReverseMap();
        }
    }
}
