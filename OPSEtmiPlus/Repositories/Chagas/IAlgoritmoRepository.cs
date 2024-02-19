using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface IAlgoritmoRepository
    {
        AlgoritmoChagas CreateAlgoritmo(int id, AlgoritmoChagas model);
    }
}
