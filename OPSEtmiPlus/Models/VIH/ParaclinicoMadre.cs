namespace OPSEtmiPlus.Models.VIH
{
    public class ParaclinicoMadre
    {
        public int IdParaclinico { get; set; }
        public int IdReporte { get; set; } 
        public int IdMomentoDiagnostico { get; set; }
        public Parametrica? MomentoDiagnostico { get; set; }
        public int IdParaclinicoRealizado { get; set; }
        public Parametrica? ParaclinicoRealizado { get; set; }
        public DateTime FechaParaclinico { get; set; }
        public int ResultadoParaclinico { get; set; }
    }
}
