namespace OPSEtmiPlus.Models.Chagas
{
    public class DiagnosticoEnfermedadGestanteChagas
    {
        public int IdDiagnosticoGestante { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdCondicionDiagnosticoChagas { get; set; }
        public Parametrica? CondicionDiagnoticoChagas { get; set; }
        public int EdadGestacionalSemanas { get; set; }
        public int EdadGestacionalPrimerControlPrentalSemanas { get; set; }
        public DateTime FechaProbableParto { get; set; }
        public List<AlgoritmoChagas>? AlgoritmoChagas { get; set; } = [];
    }
}
