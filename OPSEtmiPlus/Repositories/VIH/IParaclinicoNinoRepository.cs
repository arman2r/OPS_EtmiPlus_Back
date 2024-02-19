using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IParaclinicoNinoRepository
    {
        ParaclinicoNino CreateParaclinicoNino(int id, ParaclinicoNino model);
        ParaclinicoNino UpdateParaclinicoNino(int id, ParaclinicoNino model);
    }
}
