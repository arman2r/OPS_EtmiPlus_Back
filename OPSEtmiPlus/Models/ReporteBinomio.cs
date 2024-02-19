namespace OPSEtmiPlus.Models
{
    public class ReporteBinomio
    {
        public int IdGestante { get; set; }
        public int IdBinomio { get; set; }
        public string NombreIPSAtencionVIH { get; set; } = string.Empty;
        public string NombreRemitenteInformacion { get; set; } = string.Empty;
        public string CargoRemitenteInformacion { get; set; } = string.Empty;
        public string TelefonoRemitenteInformacion { get; set; } = string.Empty;
        public string CorreoRemitenteInformacion1 { get; set; } = string.Empty;
        public string CorreoRemitenteInformacion2 { get; set; } = string.Empty;
    }
}
