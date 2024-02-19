namespace OPSEtmiPlus.Models.Chagas
{
    public class SeguimientoNinoExpuestoChagas
    {
        public int IdSeguimientoNinoExpuesto { get; set; }
        public int IdDiagnosticoNinoExpuesto { get; set; }
        public DateTime FechaNacimiento {  get; set; }
        public int IdCondicionRecienNacido { get; set; }
        public Parametrica? CondicionRecienNacido { get; set; }
        public int IdNumeroProductosNacimiento { get; set; }
        public Parametrica? NumeroProductosNacimiento { get; set; }
        public int EdadGestacionalNacimientoSemanas { get; set; }
        public double PesoGramos {  get; set; }
        public int IdSexo {  get; set; }
        public Parametrica? Sexo { get; set; }
        public int IdTipoParto {  get; set; }
        public Parametrica? TipoParto { get; set; }
        public int IdTipoRegimenSalud {  get; set; }
        public Parametrica? TipoRegimenSalud { get; set; }
        public string NombreAseguradoraEAPB { get; set; } = string.Empty;
        public string NombresApellidos { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public Parametrica? TipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public List<TratamientoSeguimientoNinoChagas>? TratamientosSeguimientoNinoChagas { get; set; } = [];
    }
}
