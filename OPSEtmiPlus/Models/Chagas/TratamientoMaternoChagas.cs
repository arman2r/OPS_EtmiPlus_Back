namespace OPSEtmiPlus.Models.Chagas
{
    public class TratamientoMaternoChagas
    {
        public int IdTratamientoMaterno { get; set; }
        public int IdAlgoritmo { get; set; }
        public int BenznidazolX60Dias { get; set; }
        public DateTime FechaInicioTratamiento { get; set; }
        public int NufurtimoxX60Dias { get; set; }
        public int IdNufurtimoxControlesMedicos { get; set; }
        public Parametrica? NufurtimoxControlesMedicos { get; set; }
        public int FinalizacionLactanciaMaterna { get; set; }
        public string MetodoAnticonceptivoUtilizadoDuranteTratamiento { get; set; } = string.Empty;
    }
}
