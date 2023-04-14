using static MeteoGalicia.Controllers.MeteorologyController;

namespace MeteoGalicia.Entities
{
    public class Municipality
    {
        public List<ListaObservacionConcello> ListaObservacionConcellos { get; set; }
    }

    public partial class ListaObservacionConcello
    {
        public DateTimeOffset DataLocal { get; set; }
        public DateTimeOffset DataUtc { get; set; }
        public long IcoEstadoCeo { get; set; }
        public long IcoVento { get; set; }
        public long IdConcello { get; set; }
        public string NomeConcello { get; set; }
        public double SensacionTermica { get; set; }
        public double Temperatura { get; set; }
    }
}
