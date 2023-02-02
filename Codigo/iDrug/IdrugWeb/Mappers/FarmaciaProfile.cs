using AutoMapper;
using Core;
using IdrugWeb.Models;


namespace IdrugWeb.Mappers
{
    public class FarmaciaProfile : Profile
    {
        public FarmaciaProfile()
        {
            CreateMap<FarmaciaModel, Farmacia>().ReverseMap();
        }
    }
}
