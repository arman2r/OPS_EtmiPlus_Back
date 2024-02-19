namespace OPSEtmiPlus.Models.HepatitisB
{
    public class DiagnosticoGestanteHB
    {       
        public int IdDiagnosticoGestante { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdMomentoDiagnostico { get; set; }
        public Parametrica? MomentoDiagnostico { get; set; }
        public int EdadGestacional { get; set; }
        public DateTime FechaResultadoReactivo { get; set; } 
        public int ResultadoAntiHBcIgM {  get; set; }
        public DateTime FechaResultadoAntiHBcIgM { get; set; }
        public int ResultadoAntiHBcTotalOlgG { get; set; }
        public DateTime FechaResultadoAntiHBcTotalOlgG { get; set; }
        public int ResultadoAntiHBeAg { get; set; }
        public DateTime FechaResultadoAntiHBeAg { get; set; }
        public int ResultadoAntigenoCargaViral { get; set; }
        public DateTime FechaResultadoCargaViral {  get; set; }        
        public List<TratamientoSeguimientoGestanteHB>? TratamientoSeguimientoGestante {  get; set; }
    }
}
