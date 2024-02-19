namespace OPSEtmiPlus.Models.Sifilis
{
    public class DiagnosticoEIntervencionNino
    {
        public int IdDiagnosticoEIntervencionNino { get; set; }
        public int IdGestanteControl { get; set; }
        public int EsDiagnosticoDescartado { get; set; }
        public int SeAplicoDosisProfilacticaPenicilinaBenzatinica { get; set; }
        public int EsConfirmadoSifilisCongenita { get; set; }
        public int SeAplicoTratamiento { get; set; }
        public int RecibioTratamientoDePenicilinaCristalina { get; set; }
        public int RecibioTratamientoDePenicilinaCristalina10Dias { get; set; }

        //Criterio utilizado para el diagnostico de sifilis congenita en niñ@
        public int IdCriterioUtilizado { get; set; } //CRITERIO_UTILIZADO
        public Parametrica? CriterioUtilizado { get; set; }
        public List<SeguimientoNinoPrimerAnio> SeguimientosNinoPrimerAnio { get; set; } = [];
    }
}
