namespace OPSEtmiPlus.Models.HepatitisB
{
    public class SeguimientoNinoExpuestoHB
    {
        public int IdSeguimientoNinoExpuesto { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdCondicionRecienNacido { get; set; }
        public Parametrica? CondicionRecienNacido { get; set; }
        public int EdadGestacionalNacimientoSemanas { get; set; }
        public int IdTipoParto { get; set; }
        public Parametrica? TipoParto { get; set; }
        public int IdNumeroProductosNacimiento { get; set; }
        public Parametrica? NumeroProductosNacimiento { get; set; }
        public DateTime FechaParto { get; set; }
        public int IdSexo { get; set; }
        public Parametrica? Sexo {  get; set; }
        public int IdTipoRegimenSalud {  get; set; }
        public Parametrica? TipoRegimenSalud { get; set; }
        public string NombreAseguradora { get; set; } = string.Empty;
        public string DireccionTerritorial { get; set; } = string.Empty; //Si no es asegurado se debe llenar
        public string NombresApellidos {  get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public Parametrica? TipoDocumento {  get; set; }
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public int AplicaronDosisVacunaRecienNacido { get; set; }
        public int IdTiempoAplicacionVacuna { get; set; }
        public Parametrica? TiempoAplicacionVacuna { get; set; }
        public int AplicaronInmunoglobulinaRecienNacido { get; set; }
        public int IdTiempoAplicacionInmonoglobulina { get; set; }    
        public Parametrica? TiempoAplicacionInmonoglobulina { get; set; }
        public List<VacunacionHB> Vacunacion { get; set; } = [];
        public List<ClasificacionNinoExpuestoHB> ClasificacionNinoExpuesto { get; set; } = [];
    }
}
