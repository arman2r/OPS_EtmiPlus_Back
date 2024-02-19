namespace OPSEtmiPlus.Models.VIH
{
    public class Reporte5
    {
        public int IdReporte { get; set; }
        public int IdGestanteControl { get; set; }
        public DateTime FechaPruebaRealizadaADNProviral {  get; set; }
        public int IdTipoPrueba {  get; set; }
        public Parametrica? TipoPrueba { get; set; }
        public DateTime FechaPrueba { get; set; }
        public string ResultadoPrueba { get; set; } = string.Empty;
        public int IdTipoAlimentacionNinoExpuesto { get; set; }
        public Parametrica? TipoAlimentacionNinoExpuesto { get; set; }
        public int IdSituacionNinoExpuesto { get; set; }
        public Parametrica? SituacionNinoExpuesto { get; set; }
        public List<ParaclinicoNino>? ListParaclinicos { get; set; } = [];
    }
}
