using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface ITratamientoMaternoRepository
    {
        TratamientoMaternoChagas CreateTratamientoMaterno(int id, TratamientoMaternoChagas model);
    }
}
