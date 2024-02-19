namespace OPSEtmiPlus.Models.Chagas.DTOs
{
    public class ChagasCompleto
    {
        public int IdGestanteControl { get; set; }
        public List<DiagnosticoEnfermedadGestanteChagas> DiagnosticoCompletoGestante { get; set; } = [];
        public List<DiagnosticoNinoExpuestoChagas> DiagnosticoNinoExpuestoChagas { get; set; } = [];
    } 
}
