namespace OPSEtmiPlus.Models.Sifilis
{
    public class AplicacionPenicilinaBenzatinica
    {
        public int IdAplicacionPenicilinaBenzatinica { get; set; }
        public int? IdTratamientoMaternoEstadioClinico { get; set; }
        public int? IdRetratamientoMaternoGestacional {  get; set; }
        public int? IdSeguimientoContactoSexual { get; set; }
        public int EsRetratamiento { get; set; } = 0;
        public int IdDosisPenicilinaBenzatinica { get; set; } //DOSIS_PENICILINA_BENZATINICA
        public Parametrica? DosisPenicilinaBenzatinica {  set; get; }
        public DateTime FechaAplicacionPenicilinaBenzatinica { get; set; }
        public int EdadGestionalAplicacionPenicilinaBenzatinicaSemanas { get; set; }
    }
}
