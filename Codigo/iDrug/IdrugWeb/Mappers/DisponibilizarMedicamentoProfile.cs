using AutoMapper;
using Core;
using IdrugWeb.Models;

namespace IdrugWeb.Mappers
{
    public class DisponibilizarMedicamentoProfile : Profile
    {
        public DisponibilizarMedicamentoProfile()
        {
            CreateMap<DisponibilizarMedicamentoModel, Medicamentodisponivel>().ReverseMap();
        }
    }
}
