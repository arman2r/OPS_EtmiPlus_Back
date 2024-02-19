namespace OPSEtmiPlus.Models.Chagas
{
    public class TratamientoSeguimientoNinoChagas
    {
        public int IdTratamientoSeguimientoNino { get; set; }
        public int IdSeguimientoNinoExpuesto { get; set; }
        public int BenznidazolX60Dias { get; set; }
        public DateTime FechaInicioTratamiento { get; set; }
        public int NufurtimoxX60Dias { get; set; }
        public int IdNufurtimoxControlesMedicos { get; set; }
        public Parametrica? NufurtimoxControlesMedicos { get; set; }

        //Prueba de serológico a los 6 meses de terminar tratamiento
        public int EsAntigenosTotales6Meses { get; set; }
        public int EsAntigenosRecombinantes6Meses { get; set; }
        public string ResultadoPruebaSerologica6Meses { get; set; } = string.Empty;

        //Prueba de serológico a los 12 meses de terminar tratamiento
        public int EsAntigenosTotales12Meses { get; set; }
        public int EsAntigenosRecombinantes12Meses { get; set; }
        public string ResultadoPruebaSerologica12Meses { get; set; } = string.Empty;

        //Resultado
        public int EsNinoCuradoChagas { get; set; }
    }
}
