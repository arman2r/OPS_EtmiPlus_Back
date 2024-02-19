using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IParaclinicoMadreRepository
    {
        ParaclinicoMadre CreateParaclinicoMadre(int id, ParaclinicoMadre model);
        ParaclinicoMadre UpdateParaclinicoMadre(int id, ParaclinicoMadre model);
    }
}
