using OPSEtmiPlus.Models.VIH.DTOs;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IVIHRepository
    {
        VIHCompleto GetVIHCompleto(int id);
    }
}
