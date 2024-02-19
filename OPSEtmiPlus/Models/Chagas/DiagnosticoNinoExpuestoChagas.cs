namespace OPSEtmiPlus.Models.Chagas
{
    public class DiagnosticoNinoExpuestoChagas
    {
        public int IdDiagnosticoNinoExpuesto {  get; set; }
        public int IdGestanteControl {  get; set; }
        public int FechaNacimiento {  get; set;}

        //Prueba Diagnostico al momento de nacer
        public int IdExamenParasitologico { get; set; }
        public Parametrica? ExamenParasitologico { get; set;}
        public string ResultadoExamenParasitologico { get; set; } = string.Empty;
        public DateTime FechaRecoleccionMuestra { get; set; }
        public DateTime FechaEmisiónResultado { get; set; }

        //En caso de ser positiva, prueba diagnostico al momento de nacer a los 3 meses de nacido
        public int SeHacePruebaDiagnostica3Meses {  get; set; }
        public int IdExamenParasitologico3Meses { get; set; }
        public string ResultadoExamenParasitologico3Meses { get; set; } = string.Empty;
        public DateTime FechaRecoleccionMuestra3Meses { get; set; }
        public DateTime FechaEmisiónResultado3Meses { get; set; }

        //Prueba de diagnostico molecular por criterio clinico o epidemiológico
        public int SeHacePrueebaDiagnosticoMolecular {  get; set; }
        public string ResultadoPCR { get; set; } = string.Empty;
        public DateTime FechaRecolecionPCR {  get; set; }
        public DateTime FechaEmisionPCR {  get; set; }
        
        //Prueba de diagnostico serológico a los 10 meses de nacido si las de pruebas de diagn´stico directo al momento y a los 3 meses de naces es negativa
        public int SeHacePruebaDiagnostico10Meses {  get; set; }
        public int EsAntigenosTotales {  get; set; }
        public int EsAntigenosRecombinantes { get; set; }
        public int ResultadoPrueba {  get; set; }
        public DateTime FechaRecoleccionMuestra10Meses {  get; set; }
        public DateTime FechaEmisionResultado10Meses { get; set; }

        //Confirmación
        public int EsCasoConfirmadoTMIChagas {  get; set; }
        public List<SeguimientoNinoExpuestoChagas>? SeguimientoNinoExpuestoChagas { get; set; } = [];
    }
}
