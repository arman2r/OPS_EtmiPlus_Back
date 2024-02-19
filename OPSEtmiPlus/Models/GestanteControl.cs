namespace OPSEtmiPlus.Models
{
    public class GestanteControl
    {
        public int IdGestanteControl {  get; set; }
        public int IdGestante {  get; set; }
        public DateTime FechaControl { get; set; }
        public ControlEstadoFichas? ControlEstadoFichas { get; set; }
    }

    public class ControlEstadoFichas
    {
        public bool TieneFichaVIH { get; set; }
        public bool TieneFichaSifilis { get; set; }
        public bool TieneFichaHepatitisB {  get; set; }
        public bool TieneFichaChagas { get; set; }
    }
}
