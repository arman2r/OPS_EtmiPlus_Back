namespace OPSEtmiPlus.Models
{
    public class ReporteEAPB
    {
        public int IdGestante { get; set; }
        public int IdReporteEAPB { get; set; }
        public DateTime FechaReporte {  get; set; }
        public string NombreEAPB { get; set; } = string.Empty;
        public string NombreRemitenteInformacion { get; set; } = string.Empty;
        public string CargoRemitenteInformacion { get; set; } = string.Empty;
        public string TelefonoMovilRemitenteInformacion { get; set; } = string.Empty;
        public string TelefonoFijoRemitenteInformacion { get; set; } = string.Empty;
        public string CorreoRemitenteInformacion1 { get; set; } = string.Empty;
        public string CorreoRemitenteInformacion2 { get; set; } = string.Empty;
    }
}
