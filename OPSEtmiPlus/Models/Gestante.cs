using System;
using System.Collections.Generic;

namespace OPSEtmiPlus.Models
{
    public class Gestante
    {
        public int IdGestante { get; set; }
        public string NombresApellidos { get; set; } = String.Empty;
        public int IdNacionalidad { get; set; }
        public Parametrica? Nacionalidad { get; set; }
        public int IdTipoDocumento { get; set; }
        public Parametrica? TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = String.Empty;
        public int Edad { get; set; }
        public int IdTipoRegimenSalud { get; set; }
        public Parametrica? TipoRegimenSalud { get; set; }
        public string NombreAseguradora { get; set; } = String.Empty;
        public int IdPertenenciaEtnica { get; set; }
        public Parametrica? PertenenciaEtnica { get; set; }
        public int IdGrupoPoblacional { get; set; }
        public Parametrica? GrupoPoblacional { get; set; }
        public int IdAreaOcurrencia { get; set; }
        public Parametrica? AreaOcurrencia { get; set; }
        public int IdDptoResidencia { get; set; }
        public int IdMunicipioResidencia { get; set; }
        public string DireccionResidencia { get; set; } = String.Empty;
        public int IdDptoAtencion { get; set; }
        public int IdMunicipioAtencion { get; set; }
        public string Telefono { get; set; } = String.Empty;
        public DateTime FechaPosibleParto { get; set; } //Sifilis
        public int SeRealizaControlPrenatal {  get; set; } //HepatitisB
        public int EdadGestacionalSemanas { get; set; } //HepatitisB
    }

}
