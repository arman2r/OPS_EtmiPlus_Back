namespace OPSEtmiPlus.Models.Sifilis.DTOs
{
    public class SifilisCompleto
    {
        public int IdGestanteControl { get; set; }
        public List<DiagnosticoMaterno> DiagnosticoMaterno { get; set; } = [];
        public List<SituacionGestanteEmbarazoActual> SituacionGestanteEmbarazoActual { get; set; } = [];
        public List<DiagnosticoEIntervencionNino> DiagnosticoEIntervencionNino { get; set; } = [];
        public List<SeguimientoContactoSexual> SeguimientoContactoSexual { get; set; } = [];
    }
}
