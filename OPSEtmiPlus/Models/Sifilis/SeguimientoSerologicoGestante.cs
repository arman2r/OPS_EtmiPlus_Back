namespace OPSEtmiPlus.Models.Sifilis
{
    public class SeguimientoSerologicoGestante
    {
        public int IdSeguimientoSerologicoGestante { get; set; }
        public int IdTratamientoMaternoEstadioClinico { get; set; }
        public int IdTipoPruebaNoTreponemicaDuranteGestacion {  get; set; } //TIPO_PRUEBA_NO_TREPONEMICA
        public Parametrica? TipoPruebaNoTreponemicaDuranteGestacion { get; set; }
        public DateTime FechaResultadoPruebaNoTreponemica { get; set; }
        public int IdDilucionesPruebaNoTreponemicaEsReactiva {  get; set; }
        public Parametrica? DilucionesPruebaNoTreponemicaEsReactiva { get; set; } //DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA
        public int EdadGestacionalRealizacionPruebaNoTreponemica { get; set; }
    }
}
