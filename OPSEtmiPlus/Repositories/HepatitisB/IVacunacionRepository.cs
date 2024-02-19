using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface IVacunacionRepository
    {
        VacunacionHB CreateVacunacion(int id, VacunacionHB model);
    }
}
