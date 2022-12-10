using IdrugWeb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

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
