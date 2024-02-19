namespace OPSEtmiPlus.Models.Sifilis
{
    public class RetratamientoMaternoGestacional
    {
        public int IdRetratamientoMaternoGestacional { get; set; }
        public int IdTratamientoMaternoEstadioClinico { get; set; }
        public int RequirioTratamiento { get; set; }
        public int IdCausaRetratamiento { get; set; } //CAUSA_RETRATAMIENTO
        public Parametrica? CausaRetratamiento { get; set; }
        public int AplicaronPenicilinaBenzatinica { get; set; }
        public List<AplicacionPenicilinaBenzatinica>? ListAplicacionPenicilinaBenzatinica = [];
    }
}
