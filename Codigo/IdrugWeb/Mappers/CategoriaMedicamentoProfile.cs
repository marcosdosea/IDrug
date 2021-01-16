using AutoMapper;
using Core;
using IdrugWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
