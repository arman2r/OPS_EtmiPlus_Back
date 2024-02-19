using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.Chagas.DTOs;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models.Sifilis.DTOs;
using OPSEtmiPlus.Services;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class SifilisRepository: ISifilisRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SifilisController> _logger;

        public SifilisRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SifilisController>)logger;
        }

        public SifilisCompleto GetSifilisCompleto(int id)
        {
            _logger.LogInformation($"Executing repository SifilisCompleto to GetSifilisCompleto {id}");

            var model = new SifilisCompleto();
            model.IdGestanteControl = id;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    #region Gestante
                    //Get DiagnosticoMaterno
                    model.DiagnosticoMaterno = GetDiagnosticoMaterno(connection, id);
                    //Get SituacionGestanteEmbarazoActual
                    model.SituacionGestanteEmbarazoActual = GetSituacionGestanteEmbarazoActual(connection, id);
                    #endregion

                    #region Nino
                    //Get SituacionGestanteEmbarazoActual
                    model.DiagnosticoEIntervencionNino = GetDiagnosticoEIntervencionNino(connection, id);
                    #endregion

                    #region ContactoSexual
                    model.SeguimientoContactoSexual = GetSeguimientoContactoSexual(connection, id);
                    #endregion

                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        //Get Gestante
        private List<DiagnosticoMaterno> GetDiagnosticoMaterno(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_DiagnosticoMaterno WHERE IdGestanteControl = @Id";
            var data = connection.Query<DiagnosticoMaterno>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"DiagnosticoMaterno with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.MomentoDiagnostico = utilService.GetParametricaById(item.IdMomentoDiagnostico);
                item.PruebaTreponemica = utilService.GetParametricaById(item.IdPruebaTreponemica);
                item.ResultadoPruebaTreponemica = utilService.GetParametricaById(item.IdResultadoPruebaTreponemica);
                item.PruebaNoTreponemica = utilService.GetParametricaById(item.IdPruebaNoTreponemica);
                item.ResultadoPruebaNoTreponemica = utilService.GetParametricaById(item.IdResultadoPruebaNoTreponemica);

                List<Parametrica> listParametricas = [];
                foreach (var subItem in item.ReporteDilucionesPruebaNoTreponemicaReactiva)
                {
                    var parametrica = utilService.GetParametricaById(subItem);
                    listParametricas.Add(parametrica);
                }
                item.ListReporteDilucionesPruebaNoTreponemicaReactiva = listParametricas;
                item.TratamientoMaternoEstadioClinico = GetTratamientoMaternoEstadioClinico(connection, item.IdDiagnosticoMaterno);
            }

            return data.ToList();
        }

        private List<TratamientoMaternoEstadioClinico> GetTratamientoMaternoEstadioClinico(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_TratamientoMaternoEstadioClinico WHERE IdDiagnosticoMaterno = @Id";
            var data = connection.Query<TratamientoMaternoEstadioClinico>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"TratamientoMaternoEstadioClinico with IdDiagnosticoMaterno {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.ClasificacionEstadioClinico = utilService.GetParametricaById(item.IdClasificacionEstadioClinico);
                item.ResultadoManejoSifilisGestacional = utilService.GetParametricaById(item.IdResultadoManejoSifilisGestacional);
                item.ResultadoPrevenirSifilisCongenita = utilService.GetParametricaById(item.IdResultadoPrevenirSifilisCongenita);
                item.SeguimientoSerologicoGestante = GetSeguimientoSerologicoGestante(connection, item.IdTratamientoMaternoEstadioClinico);
                item.RetratamientoMaternoGestacional = GetRetratamientoMaternoGestacional(connection, item.IdTratamientoMaternoEstadioClinico);
                item.ListAplicacionPenicilinaBenzatinica = GetAplicacionPenicilinaBenzatinica(connection, "IdTratamientoMaternoEstadioClinico", item.IdTratamientoMaternoEstadioClinico);
            }

            return data.ToList();
        }

        private List<SeguimientoSerologicoGestante> GetSeguimientoSerologicoGestante(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_SeguimientoSerologicoGestante WHERE IdTratamientoMaternoEstadioClinico = @Id";
            var data = connection.Query<SeguimientoSerologicoGestante>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SeguimientoSerologicoGestante with IdTratamientoMaternoEstadioClinico {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.TipoPruebaNoTreponemicaDuranteGestacion = utilService.GetParametricaById(item.IdTipoPruebaNoTreponemicaDuranteGestacion);
                item.DilucionesPruebaNoTreponemicaEsReactiva = utilService.GetParametricaById(item.IdDilucionesPruebaNoTreponemicaEsReactiva);
            }

            return data.ToList();
        }

        private List<RetratamientoMaternoGestacional> GetRetratamientoMaternoGestacional(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_RetratamientoMaternoGestacional WHERE IdTratamientoMaternoEstadioClinico = @Id";
            var data = connection.Query<RetratamientoMaternoGestacional>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"RetratamientoMaternoGestacional with IdTratamientoMaternoEstadioClinico {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.CausaRetratamiento = utilService.GetParametricaById(item.IdCausaRetratamiento);
                item.ListAplicacionPenicilinaBenzatinica = GetAplicacionPenicilinaBenzatinica(connection, "IdRetratamientoMaternoGestacional", item.IdRetratamientoMaternoGestacional);
            }

            return data.ToList();
        }

        private List<SeguimientoContactoSexual> GetSeguimientoContactoSexual(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_SeguimientoContactoSexual WHERE IdGestanteControl = @Id";
            var data = connection.Query<SeguimientoContactoSexual>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SeguimientoContactoSexual with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.DosisPenicilinaBenzatinica = utilService.GetParametricaById(item.IdDosisPenicilinaBenzatinica);
                item.ListAplicacionPenicilinaBenzatinica = GetAplicacionPenicilinaBenzatinica(connection, "IdSeguimientoContactoSexual", item.IdSeguimientoContactoSexual);
            }

            return data.ToList();
        }        

        private List<SituacionGestanteEmbarazoActual> GetSituacionGestanteEmbarazoActual(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_SituacionGestanteEmbarazoActual WHERE IdGestanteControl = @Id";
            var data = connection.Query<SituacionGestanteEmbarazoActual>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SituacionGestanteEmbarazoActual with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.SituacionGestante = utilService.GetParametricaById(item.IdSituacionGestante);
                item.CondicionRecienNacido = utilService.GetParametricaById(item.IdCondicionRecienNacido);
                item.NumeroProductosNacimiento = utilService.GetParametricaById(item.IdNumeroProductosNacimiento);
                item.Sexo = utilService.GetParametricaById(item.IdSexo);
                item.TipoRegimenSalud = utilService.GetParametricaById(item.IdTipoRegimenSalud);
                item.TipoDocumento = utilService.GetParametricaById(item.IdTipoDocumento);
            }

            return data.ToList();
        }

        private List<DiagnosticoEIntervencionNino> GetDiagnosticoEIntervencionNino(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_DiagnosticoEIntervencionNino WHERE IdGestanteControl = @Id";
            var data = connection.Query<DiagnosticoEIntervencionNino>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"DiagnosticoEIntervencionNino with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.CriterioUtilizado = utilService.GetParametricaById(item.IdCriterioUtilizado);
                item.SeguimientosNinoPrimerAnio = GetSeguimientoNinoPrimerAnio(connection, item.IdDiagnosticoEIntervencionNino);
            }

            return data.ToList();
        }

        private List<SeguimientoNinoPrimerAnio> GetSeguimientoNinoPrimerAnio(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_SeguimientoNinoPrimerAnio WHERE IdDiagnosticoEIntervencionNino = @Id";
            var data = connection.Query<SeguimientoNinoPrimerAnio>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SeguimientoNinoPrimerAnio with IdDiagnosticoEIntervencionNino {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.TipoPruebaNoTreponemica = utilService.GetParametricaById(item.IdTipoPruebaNoTreponemica);
                item.DilucionesPruebaNoTreponemica = utilService.GetParametricaById(item.IdDilucionesPruebaNoTreponemica);
            }

            return data.ToList();
        }

        private List<AplicacionPenicilinaBenzatinica> GetAplicacionPenicilinaBenzatinica(SqlConnection connection, string field, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Sifilis_AplicacionPenicilinaBenzatinica WHERE " + field + " = @Id";
            var data = connection.Query<AplicacionPenicilinaBenzatinica>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"AplicacionPenicilinaBenzatinica with IdAplicacionPenicilinaBenzatinica {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.DosisPenicilinaBenzatinica = utilService.GetParametricaById(item.IdDosisPenicilinaBenzatinica);
            }

            return data.ToList();
        }
    }
}
