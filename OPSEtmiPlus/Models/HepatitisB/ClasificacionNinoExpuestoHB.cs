namespace OPSEtmiPlus.Models.HepatitisB
{
    public class ClasificacionNinoExpuestoHB
    {      
        public int IdClasificacionNinoExpuesto { get; set; }
        public int IdSeguimientoNinoExpuesto { get; set; }
        public int IdResultadoAntiHBsAg { get; set; } //RESULTADO_PRUEBA
        public Parametrica? ResultadoAntiHBsAg {  get; set; }
        public DateTime FechaResultadoAntiHBsAg { get; set; }
        public int IdResultadoAntiHBs { get; set; } //RESULTADO_PRUEBA
        public Parametrica? ResultadoAntiHBs { get; set; }
        public DateTime FechaResultadoAntiHBs { get; set; }
        public int IdCondicionFinal {  get; set; } //CONDICION_FINAL_NINO_EXPUESTO
        public Parametrica? CondicionFinal { get; set; }
        public int IdClasificacionFinal { get; set; } //CLASIFICACION_FINAL_NINO_EXPUESTO
        public Parametrica? ClasificacionFinal { get; set; } //CLASIFICACION_FINAL_NINO_EXPUESTO
    }
}
