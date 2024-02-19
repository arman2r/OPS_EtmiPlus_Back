namespace OPSEtmiPlus.Models.Sifilis
{
    public class SeguimientoNinoPrimerAnio
    {
        public int IdSeguimientoNinoPrimerAnio { get; set; }
        public int IdDiagnosticoEIntervencionNino { get; set; }
        public int SeRealizoSeguimiento { get; set; }
        public int IdTipoPruebaNoTreponemica { get; set; } //TIPO_PRUEBA_NO_TREPONEMICA
        public Parametrica? TipoPruebaNoTreponemica { get; set; }
        public DateTime FechaResultado { get; set; }
        public int IdDilucionesPruebaNoTreponemica { get; set; } //DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA
        public Parametrica? DilucionesPruebaNoTreponemica { get; set; }
        public int CumpleCriteriosCuracion { get; set; }
    }
}
