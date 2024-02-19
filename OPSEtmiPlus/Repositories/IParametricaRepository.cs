using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public interface IParametricaRepository
    {
        Parametrica GetParametricasById(int id);
        List<Parametrica> GetParametricasByName(string Name);
    }
}
