namespace OPSEtmiPlus.Models.VIH
{
    public class Reporte3
    {
        public int IdReporte { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdSituacionGestante { get; set; } //SITUACION_GESTANTE
        public Parametrica? SituacionGestante { get; set; }
        public DateTime FechaDelParto { get; set; }
        public int IdEsquemaAntirretroviralIntraparto { get; set; } //ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO
        public Parametrica? EsquemaAntirretroviralIntraparto { get; set; }
        public int IdEsquemaArvIntraparto { get; set; } //ESQUEMA_ARV_INTRAPARTO
        public Parametrica? EsquemaArvIntraparto { get; set; }
        public int IdCondicionRecienNacido { get; set; } //CONDICION_RECIEN_NACIDO
        public Parametrica? CondicionRecienNacido { get; set; }
        public int IdNumeroDeProductosNacimiento { get; set; } //NUMERO_PRODUCTOS_NACIMIENTO
        public Parametrica? NumeroDeProductosNacimiento { get; set; }
        public int EdadGestacionalNacimientoSemanas { get; set; }
        public int PesoRecienNacidoGramos { get; set; }
        public int IdSexo { get; set; } //SEXO
        public Parametrica? Sexo { get; set; }
        public int IdTipoParto { get; set; } //TIPO_PARTO
        public Parametrica? TipoParto { get; set; }
        public int SeRealizoSuprecionLactancia { get; set; }
        public string MedicamentoSuministrado { get; set; } = string.Empty;
    }
}
