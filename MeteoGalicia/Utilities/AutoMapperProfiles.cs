using AutoMapper;
using MeteoGalicia.DTOs;
using MeteoGalicia.Entities;

namespace MeteoGalicia.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ListaPredDiaConcello, MunicipalityPredictionGet>();
        }
    }
}
