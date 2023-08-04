using AutoMapper;
using Core;
using IdrugWeb.Models;

namespace IdrugWeb.Mappers
{
    public class SolicitarMedicamentoProfile : Profile
    {
        public SolicitarMedicamentoProfile()
        {
            CreateMap<SolicitacaoMedicamentoModel, Solicitacaomedicamento>().ReverseMap();
        }
    }
}
