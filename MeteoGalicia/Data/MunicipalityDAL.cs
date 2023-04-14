using MeteoGalicia.Entities;
using MeteoGalicia.Model;

namespace MeteoGalicia.Data
{
    public class MunicipalityDAL
    {
        private readonly MunicipalityBLL bLL;

        public MunicipalityDAL(MunicipalityBLL bLL)
        {
            this.bLL = bLL;
        }

        public async Task<List<ListaPredDiaConcello>> MeteorologyMunicipality(string municipio)
        {
            long codeMunicipality = await bLL.AllMunicipalitySearch(municipio);
            List<ListaPredDiaConcello> list = await bLL.ByMunicipalityFind(codeMunicipality);

            return list;
        }
    }
}
