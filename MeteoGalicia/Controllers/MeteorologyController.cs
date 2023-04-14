using AutoMapper;
using MeteoGalicia.Data;
using MeteoGalicia.DTOs;
using MeteoGalicia.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeteoGalicia.Controllers
{
    [ApiController]
    [Route("api/observacion")]
    public class MeteorologyController : Controller
    {
        private readonly IMapper mapper;
        private readonly MunicipalityDAL dAL;

        public MeteorologyController(IMapper mapper, MunicipalityDAL dAL)
        {
            this.mapper = mapper;
            this.dAL = dAL;
        }

        [HttpGet("{municipio}", Name = "getMeteorology")]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<MunicipalityPredictionGet>>> Get(string municipio)
        {
            List<ListaPredDiaConcello> list = await dAL.MeteorologyMunicipality(municipio);
            var result = mapper.Map<List<MunicipalityPredictionGet>>(list);

            if (result.Count == 0) return NotFound($"No se encontraron datos con el municipio/concello: {municipio}");

            return Ok(result);
        }
    }
}
