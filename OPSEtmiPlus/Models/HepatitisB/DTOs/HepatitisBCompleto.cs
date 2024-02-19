namespace OPSEtmiPlus.Models.HepatitisB.DTOs
{
    public class HepatitisBCompleto
    {
        public int IdGestanteControl { get; set; }
        public List<DiagnosticoGestanteHB> DiagnosticoGestante { get; set; } = [];
        public List<SeguimientoNinoExpuestoHB> SeguimientoNinoExpuesto { get; set; } = [];

    }
}
