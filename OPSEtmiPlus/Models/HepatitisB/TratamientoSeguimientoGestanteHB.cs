namespace OPSEtmiPlus.Models.HepatitisB
{
    public class TratamientoSeguimientoGestanteHB
    {
        public int IdTratamientoSeguimiento { get; set; }
        public int IdDiagnosticoGestante { get; set; } 
        public int RecibioTratamientoAntesEmbarazoActual { get; set; }
        public int RequiereTratamientoAntesEmbarazoActual {  get; set; }
        public int EdadGestacionalRecibioTratamientoAntesSemana { get; set; }
        public int RequiereTratamientoDuranteEmbarazoActual { get; set; }
        public int EdadGestacionalRecibioTratamientoDuranteSemana { get; set; }
        public string NombreMedicamentoTratamiento { get; set; } = string.Empty;
        public int IdSituacionGestante { get; set; }
        public Parametrica? SituacionGestante { get; set; }
    }
}
