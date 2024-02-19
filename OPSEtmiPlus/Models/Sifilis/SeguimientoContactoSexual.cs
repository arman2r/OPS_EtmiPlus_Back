namespace OPSEtmiPlus.Models.Sifilis
{
    public class SeguimientoContactoSexual
    {
        public int IdSeguimientoContactoSexual { get; set; }
        public int IdGestanteControl { get; set; }
        public int SeNotifico { get; set; }
        public int SeRealizoTratamiento { get; set; }
        public int SeAplicoPenicilinaBenzatinica { get; set; }
        public int IdDosisPenicilinaBenzatinica { get; set; } //DOSIS_PENICILINA_BENZATINICA
        public Parametrica? DosisPenicilinaBenzatinica { get; set; }
        public DateTime FechaAplicacionPenicilinaBenzatinica { get; set; }
        public string NombreMedicamentoDiferentePenicilinaBenzatinica { get; set; } = string.Empty;
        public List<AplicacionPenicilinaBenzatinica>? ListAplicacionPenicilinaBenzatinica = [];
    }
}
