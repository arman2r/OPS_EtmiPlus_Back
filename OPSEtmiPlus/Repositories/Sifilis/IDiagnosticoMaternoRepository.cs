using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface IDiagnosticoMaternoRepository
    {
        DiagnosticoMaterno CreateDiagnosticoMaterno(int id, DiagnosticoMaterno model);
    }
}
