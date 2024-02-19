namespace OPSEtmiPlus.Models.Sifilis
{
    public class TratamientoMaternoEstadioClinico
    {
        public int IdTratamientoMaternoEstadioClinico { get; set; }
        public int IdDiagnosticoMaterno { get; set; }
        public int IdClasificacionEstadioClinico { get; set; } //CLASIFICACION_ESTADIO_CLINICO
        public Parametrica? ClasificacionEstadioClinico { get; set; }
        public int AplicaronPenicilinaBenzatinica { get; set; }        
        public int IdResultadoManejoSifilisGestacional {  get; set; } //MANEJO_RESULTADO_SIFILIS
        public Parametrica? ResultadoManejoSifilisGestacional { get; set; }
        public int SeRealizoDesensibilizacionAplicacionPenicilinaBenzatinica { get; set; }
        public int IdResultadoPrevenirSifilisCongenita {  get; set; } //MANEJO_RESULTADO_SIFILIS
        public Parametrica? ResultadoPrevenirSifilisCongenita { get; set; }
        public List<SeguimientoSerologicoGestante>? SeguimientoSerologicoGestante { get; set; } = [];
        public List<RetratamientoMaternoGestacional>? RetratamientoMaternoGestacional { get; set; } = [];
        public List<AplicacionPenicilinaBenzatinica>? ListAplicacionPenicilinaBenzatinica = [];
    }
}
