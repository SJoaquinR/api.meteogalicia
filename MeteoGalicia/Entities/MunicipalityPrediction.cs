using static MeteoGalicia.Controllers.MeteorologyController;

namespace MeteoGalicia.Entities
{
    public class MunicipalityPrediction
    {
        public PredConcello PredConcello { get; set; }
    }

    public partial class PredConcello
    {
        public long IdConcello { get; set; }
        public List<ListaPredDiaConcello> ListaPredDiaConcello { get; set; }
        public string Nome { get; set; }
    }

    public partial class ListaPredDiaConcello
    {
        public Ceo Ceo { get; set; }
        public DateTimeOffset DataPredicion { get; set; }
        public long? NivelAviso { get; set; }
        public Ceo Pchoiva { get; set; }
        public long TMax { get; set; }
        public long TMin { get; set; }
        public Ceo TmaxFranxa { get; set; }
        public Ceo TminFranxa { get; set; }
        public long UvMax { get; set; }
        public Ceo Vento { get; set; }
        public Situation Situation { get; set; } = new Situation();
    }

    public partial class Situation
    {
        public string? Manha { get; set; } 
        public string? Tarde { get; set; }
        public string? Noite { get; set; }
    }

    public partial class Ceo
    {
        public long Manha { get; set; }
        public long Noite { get; set; }
        public long Tarde { get; set; }
    }
}
