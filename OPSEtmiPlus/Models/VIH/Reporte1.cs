namespace OPSEtmiPlus.Models.VIH
{
    public class Reporte1
    {
        public int IdReporte { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdMomentoDiagnostico { get; set; }
        public Parametrica? MomentoDiagnostico { get; set; }
        public int IdPruebaConfirmarVih { get; set; } //PRUEBA_DIAGNOSTICO_VIH
        public Parametrica? PruebaConfirmarVih { get; set; }
        public DateTime FechaDiagnostico { get; set; }
        public int IdResultados { get; set; } //RESULTADO_PRUEBA
        public int NumeroCopias { get; set; } //Nota: si el diagnóstico se realizó con carga viral registre el número de copias/ml(no registre el logaritmo)
        public int EstabaRecibiendoTARAntesEmbarazo { get; set; }
        public int RecibioTARDuranteEmbarazo { get; set; }
        public int EdadGestacionalInicioTARSemanas {  get; set; }
        public int EstabaRecibiendoTARDuranteEmbarazoActual { get; set; }
        public int EdadGestacionalCuandoRecibioTAR { get; set; }
        public int EdadGestacionalAlDianosticoVIHSemanas { get; set; }
        public string MedicamentosARVSuministrados { get; set; } = string.Empty; //Debe llegar un array string ej: "[48, 50, 51]"
        public int SeRealizoControlPrenatalDuranteEmbarazo { get; set; }
        public int EdadGestacionalPrimerControlPrenatalSemanas { get; set; }
        public DateTime FechaProbableParto { get; set; }
        public List<ParaclinicoMadre>? ListParaclinicos { get; set; } = [];
    }
}
