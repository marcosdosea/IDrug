using AutoMapper;
using Core;
using IdrugWeb.Models;

namespace IdrugWeb.Mappers
{
    public class CategoriaMedicamentoProfile : Profile
    {
        public CategoriaMedicamentoProfile()
        {
            CreateMap<CategoriaMedicamentoModel, Categoriamedicamento>().ReverseMap();
        }
    }
}
