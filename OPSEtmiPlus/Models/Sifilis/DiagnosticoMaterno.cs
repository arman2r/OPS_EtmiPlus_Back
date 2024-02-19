namespace OPSEtmiPlus.Models.Sifilis
{
    public class DiagnosticoMaterno
    {
        public int IdDiagnosticoMaterno {  get; set; }
        public int IdGestanteControl { get; set; }
        public int IdMomentoDiagnostico {  get; set; }
        public Parametrica? MomentoDiagnostico { get; set; }
        public int EdadGestacionalDuranteSemanas {  get; set; }
        //Control prenatal
        public int SeRealizoControlPrenatalDuranteEmbarazo { get; set; }
        public int SeRealizoPruebaTreponemica { get; set; }
        public int IdPruebaTreponemica { get; set; } //TIPO_PRUEBA_TREPONEMICA
        public Parametrica? PruebaTreponemica { get; set; }
        public int IdResultadoPruebaTreponemica {  get; set; } //RESULTADO_PRUEBA_TREPONEMICA
        public Parametrica? ResultadoPruebaTreponemica { get; set; }
        public DateTime FechaResultadoPruebaTreponemica { get; set; }
        public int EdadGestacionalALaRealizacionPruebaTreponemicaSemanas { get; set; }
        public int SeRealizoPruebaNoTreponemica { get; set; }
        public int IdPruebaNoTreponemica { get; set; } //TIPO_PRUEBA_NO_TREPONEMICA
        public Parametrica? PruebaNoTreponemica { get; set; }
        public int IdResultadoPruebaNoTreponemica { get; set; }
        public Parametrica? ResultadoPruebaNoTreponemica { get; set; } //RESULTADO_PRUEBA_NO_TREPONEMICA
        public DateTime FechaResultadoPruebaNoTreponemica { get; set; }
        public string ReporteDilucionesPruebaNoTreponemicaReactiva { get; set; } = string.Empty; //Se Espera un Array de Id DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA
        public List<Parametrica>? ListReporteDilucionesPruebaNoTreponemicaReactiva { get; set; }
        public List<TratamientoMaternoEstadioClinico>? TratamientoMaternoEstadioClinico { get; set; } = [];
    }
}
