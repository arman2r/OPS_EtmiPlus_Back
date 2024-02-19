namespace OPSEtmiPlus.Models.Sifilis
{
    public class SituacionGestanteEmbarazoActual
    {
        public int IdSituacionGestanteEmbarazoActual { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdSituacionGestante { get; set; }
        public Parametrica? SituacionGestante { get; set; }
        public DateTime FechaParto { get; set; }
        public int IdCondicionRecienNacido { get; set; }
        public Parametrica? CondicionRecienNacido {  set; get; }
        public int IdNumeroProductosNacimiento { get; set; }
        public Parametrica? NumeroProductosNacimiento { get; set; }
        public int EdadGestacionalNacimientoSemanas { get; set; }
        public int PesoRecienNacidoGramos {  get; set; }
        public int IdSexo {  get; set; }
        public Parametrica? Sexo {  get; set; }
        public int IdTipoRegimenSalud {  get; set; }
        public Parametrica? TipoRegimenSalud { get; set; }
        public string NombreAseguradora { get; set; } = string.Empty;
        public string DireccionTerritorial { get; set; } = string.Empty; //Si no esta asegurado
        public string NombresApellidos { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public Parametrica? TipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; } = string.Empty;
    }
}
