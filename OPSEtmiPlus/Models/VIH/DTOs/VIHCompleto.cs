namespace OPSEtmiPlus.Models.VIH.DTOs
{
    public class VIHCompleto
    {
        public int IdGestanteControl {  get; set; }
        public List<Reporte1> Reporte1 { get; set; } = [];
        public List<Reporte2> Reporte2 { get; set; } = [];
        public List<Reporte3> Reporte3 { get; set; } = [];
        public List<Reporte4> Reporte4 { get; set; } = [];
        public List<Reporte5> Reporte5 { get; set; } = [];
    }

}
