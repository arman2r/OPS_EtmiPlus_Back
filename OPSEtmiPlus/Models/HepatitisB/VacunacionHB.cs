namespace OPSEtmiPlus.Models.HepatitisB
{
    public class VacunacionHB
    {
        public int IdVacuna { get; set; }
        public int IdSeguimientoNinoExpuesto { get; set; }
        public int IdDosisVacuna { get; set; }
        public Parametrica? DosisVacuna { set; get; }
        public DateTime FechaAplicacion { get; set; }
    }
}
