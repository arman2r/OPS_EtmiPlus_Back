using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface IDiagnosticoEIntervencionNinoRepository
    {
        DiagnosticoEIntervencionNino CreateDiagnosticoEIntervencionNino(int id, DiagnosticoEIntervencionNino model);
    }
}
