using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface IRetratamientoMaternoGestacionalRepository
    {
        RetratamientoMaternoGestacional CreateRetratamientoMaternoGestacional(int id, RetratamientoMaternoGestacional model);
    }
}
