using OPSEtmiPlus.Models.Chagas.DTOs;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface IChagasRepository
    {
        ChagasCompleto GetChagasCompleto(int id);
    }
}
