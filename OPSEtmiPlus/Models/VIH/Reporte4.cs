using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OPSEtmiPlus.Models.VIH
{
    public class Reporte4
    {         
        public int IdReporte { get; set; }
        public int IdGestanteControl { get; set; }
        public int IdTipoRegimenSalud { get; set; }
        public Parametrica? TipoRegimenSalud { get; set; }
        public string NombreAseguradora { get; set; } = string.Empty;
        public string NombresApellidos { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public Parametrica? TipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public int IdClasificacionTMINinoExpuesto { get; set; } //CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO
        public Parametrica? ClasificacionTMINinoExpuesto { get; set; }
        public int RecibioNinoProfilaxisAntiretroviral {  get; set; }
        public string MedicamentosAntirretroviralNinoExpuesto { get; set; } = string.Empty; //Los ids datos deben llegar en un array
        public int SeRealizoADNProviral { get; set; }
        public DateTime FechaResultadoADNProviral { get; set; }
        public string ResultadoADNProviral { get; set; } = string.Empty;
        public int SeRealizaronCargasVirales { get; set; }
        public DateTime FechaResultadoCargasVirales { get; set; }
        public int ResultadoCargasVirales { get; set; }
        public string OtrasPruebasNinoExpuesto { get; set; } = string.Empty; //Los datos deben llegar en un array
    }
}
