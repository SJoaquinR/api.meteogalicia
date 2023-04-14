using MeteoGalicia.Entities;

namespace MeteoGalicia.DTOs
{
    public class MunicipalityPredictionGet
    {
        public DateTimeOffset DataPredicion { get; set; }
        public Situation Situation { get; set; } = new Situation();
        public Ceo Pchoiva { get; set; }
        public long TMax { get; set; }
        public long TMin { get; set; }
    }
}
