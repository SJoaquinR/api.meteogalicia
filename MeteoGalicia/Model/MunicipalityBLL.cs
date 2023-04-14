using MeteoGalicia.Entities;
using System.Text.Json;

namespace MeteoGalicia.Model
{
    public class MunicipalityBLL
    {
        HttpClient httpClient = new HttpClient();
        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        private readonly IConfiguration config;

        public MunicipalityBLL(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<long> AllMunicipalitySearch(string municipio)
        {
            long codeMunicipality = 0;
            try
            {
                Municipality data = await Municipality<Municipality>("MeteoGalicia_Url:Url_AllConcellos");

                if (data == null) return codeMunicipality;
                for (int i = 0; i < data.ListaObservacionConcellos.Count - 1; i++)
                {
                    if (data.ListaObservacionConcellos[i].NomeConcello.Trim().ToUpper() == municipio.Trim().ToUpper())
                    {
                        codeMunicipality = data.ListaObservacionConcellos[i].IdConcello;
                        break;
                    }
                }

                return codeMunicipality;
            }
            catch (Exception ex)
            {
                throw new($"Error al ejecutarse allMunicipalitySearch: {ex.Message}");
            }
        }

        private async Task<TEntity> Municipality<TEntity>(string urlConfig, long codeMunicipality = 0) where TEntity : class
        {
            var response = new HttpResponseMessage();

            if (codeMunicipality != 0)
                response = await httpClient.GetAsync($"{config[urlConfig]}{codeMunicipality}");
            else
                response = await httpClient.GetAsync($"{config[urlConfig]}");

            if (!response.IsSuccessStatusCode)
                throw new($"({response.StatusCode}) en la llamada al servicio: {response.RequestMessage!.RequestUri} \n {await response.Content.ReadAsStringAsync()}");

            var responseJson = await response.Content.ReadAsStringAsync();
            var dataResult = JsonSerializer.Deserialize<TEntity>(responseJson, options);

            return dataResult;
        }

        public async Task<List<ListaPredDiaConcello>> ByMunicipalityFind(long codeMunicipality)
        {
            int cantDays = 3;
            var list = new List<ListaPredDiaConcello>();
            try
            {
                if (codeMunicipality == 0) return list;
                MunicipalityPrediction data = await Municipality<MunicipalityPrediction>("MeteoGalicia_Url:Url_ByConcellos", codeMunicipality);

                if (data == null || data.PredConcello == null) return list;
                for (int i = 0; i < cantDays; i++)
                {
                    data.PredConcello.ListaPredDiaConcello[i].Situation.Manha = situation(data.PredConcello.ListaPredDiaConcello[i].Ceo.Manha);
                    data.PredConcello.ListaPredDiaConcello[i].Situation.Tarde = situation(data.PredConcello.ListaPredDiaConcello[i].Ceo.Tarde);
                    data.PredConcello.ListaPredDiaConcello[i].Situation.Noite = situation(data.PredConcello.ListaPredDiaConcello[i].Ceo.Noite);
                    list.Add(data.PredConcello.ListaPredDiaConcello[i]);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new($"Error al ejecutarse byMunicipalityFind: {ex.Message}");
            }
        }

        private string situation(long value)
        {
            string situation = string.Empty;
            switch (value)
            {
                case 101:
                    situation = "Despejado";
                    break;

                case 102:
                    situation = "Nubes altas";
                    break;

                case 103:
                    situation = "Nubes y claros";
                    break;

                case 104:
                    situation = "Nublado 75%";
                    break;

                case 105:
                    situation = "Cubierto";
                    break;

                case 106:
                    situation = "Nieblas";
                    break;

                case 107:
                    situation = "Chubasco";
                    break;

                case 108:
                    situation = "Chubasco (75%)";
                    break;

                case 109:
                    situation = "Chubasco nieve";
                    break;

                case 110:
                    situation = "Llovizna";
                    break;

                case 111:
                    situation = "Lluvia";
                    break;

                case 112:
                    situation = "Nieve";
                    break;

                case 113:
                    situation = "Tormenta";
                    break;

                case 114:
                    situation = "Bruma";
                    break;

                case 115:
                    situation = "Bancos de niebla";
                    break;

                case 116:
                    situation = "Nubes medias";
                    break;

                case 117:
                    situation = "Lluvia débil";
                    break;

                case 118:
                    situation = "Chubascos débiles";
                    break;

                case 119:
                    situation = "Tormenta con pocas nubes";
                    break;

                case 120:
                    situation = "Agua nieve";
                    break;

                case 121:
                    situation = "Granizo";
                    break;

                case 201:
                    situation = "Despejado";
                    break;

                case 202:
                    situation = "Nubes altas";
                    break;

                case 203:
                    situation = "Nubes y claros";
                    break;

                case 204:
                    situation = "Nublado 75%";
                    break;

                case 205:
                    situation = "Cubierto";
                    break;

                case 206:
                    situation = "Nieblas";
                    break;

                case 207:
                    situation = "Chubasco";
                    break;

                case 208:
                    situation = "Chubasco (75%)";
                    break;

                case 209:
                    situation = "Chubasco nieve";
                    break;

                case 210:
                    situation = "Llovizna";
                    break;

                case 211:
                    situation = "Lluvia";
                    break;

                case 212:
                    situation = "Nieve";
                    break;

                case 213:
                    situation = "Tormenta";
                    break;

                case 214:
                    situation = "Bruma";
                    break;

                case 215:
                    situation = "Bancos de niebla";
                    break;

                case 216:
                    situation = "Nubes medias";
                    break;

                case 217:
                    situation = "Lluvia débil";
                    break;

                case 218:
                    situation = "Chubascos débiles";
                    break;

                case 219:
                    situation = "Tormenta con pocas nubes";
                    break;

                case 220:
                    situation = "Agua nieve";
                    break;

                case 221:
                    situation = "Granizo";
                    break;

                default:
                    situation = "No disponible";
                    break;
            }
            return situation;
        }
    }
}
