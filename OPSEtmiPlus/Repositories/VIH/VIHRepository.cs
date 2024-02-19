using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Models.VIH.DTOs;
using OPSEtmiPlus.Services;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class VIHRepository : IVIHRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<VIHController> _logger;

        public VIHRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<VIHController>)logger;
        }

        public VIHCompleto GetVIHCompleto(int id)
        {
            _logger.LogInformation($"Executing repository VIHCompleto to GetVIHCompleto {id}");

            var model = new VIHCompleto();
            model.IdGestanteControl = id;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    model.Reporte1 = GetReporte1(connection, id);
                    model.Reporte2 = GetReporte2(connection, id);
                    model.Reporte3 = GetReporte3(connection, id);
                    model.Reporte4 = GetReporte4(connection, id);
                    model.Reporte5 = GetReporte5(connection, id);                   
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        //Get Reporte1
        private List<Reporte1> GetReporte1(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_Reporte1 WHERE IdGestanteControl = @Id";
            var data = connection.Query<Reporte1>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"Reporte1 with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdMomentoDiagnostico > 0)
                    item.MomentoDiagnostico = utilService.GetParametricaById(item.IdMomentoDiagnostico);
                if (item.IdPruebaConfirmarVih > 0)
                    item.PruebaConfirmarVih = utilService.GetParametricaById(item.IdPruebaConfirmarVih);
                item.ListParaclinicos = GetParaclinicosMadre(connection, item.IdReporte);
            }

            return data.ToList();
        }

        //Get ParaclinicoMadre
        private List<ParaclinicoMadre> GetParaclinicosMadre(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_ParaclinicoMadre WHERE IdReporte = @Id";
            var data = connection.Query<ParaclinicoMadre>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"ParaclinicoMadre with IdReporte1 {id} not was found");
                return [];
            }

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (item.IdMomentoDiagnostico > 0)
                        item.MomentoDiagnostico = utilService.GetParametricaById(item.IdMomentoDiagnostico);
                    if (item.IdParaclinicoRealizado > 0)
                        item.ParaclinicoRealizado = utilService.GetParametricaById(item.IdParaclinicoRealizado);
                }
                return data.ToList();
            }
            return [];
        }

        //Get Reporte2
        private List<Reporte2> GetReporte2(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_Reporte2 WHERE IdGestanteControl = @Id";
            var data = connection.Query<Reporte2>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"Reporte2 with IdGestanteControl {id} not was found");
                return [];
            }
            return data.ToList();
        }

        //Get Reporte3
        private List<Reporte3> GetReporte3(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_Reporte3 WHERE IdGestanteControl = @Id";
            var data = connection.Query<Reporte3>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"Reporte3 with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdSituacionGestante > 0)
                    item.SituacionGestante = utilService.GetParametricaById(item.IdSituacionGestante);
                if (item.IdEsquemaAntirretroviralIntraparto > 0)
                    item.EsquemaAntirretroviralIntraparto = utilService.GetParametricaById(item.IdEsquemaAntirretroviralIntraparto);
                if (item.IdEsquemaArvIntraparto > 0)
                    item.EsquemaArvIntraparto = utilService.GetParametricaById(item.IdEsquemaArvIntraparto);
                if (item.IdCondicionRecienNacido > 0)
                    item.CondicionRecienNacido = utilService.GetParametricaById(item.IdCondicionRecienNacido);
                if (item.IdNumeroDeProductosNacimiento > 0)
                    item.NumeroDeProductosNacimiento = utilService.GetParametricaById(item.IdNumeroDeProductosNacimiento);
                if (item.IdSexo > 0)
                    item.Sexo = utilService.GetParametricaById(item.IdSexo);
                if (item.IdTipoParto > 0)
                    item.TipoParto = utilService.GetParametricaById(item.IdTipoParto);
            }

            return data.ToList();
        }

        //Get Reporte4
        private List<Reporte4> GetReporte4(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_Reporte4 WHERE IdGestanteControl = @Id";
            var data = connection.Query<Reporte4>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"Reporte4 with IdGestanteControl {id} not was found");
                return [];
            }

            foreach ( var item in data)
            {
                if (item.IdTipoRegimenSalud > 0)
                    item.TipoRegimenSalud = utilService.GetParametricaById(item.IdTipoRegimenSalud);
                if (item.IdTipoDocumento > 0)
                    item.TipoDocumento = utilService.GetParametricaById(item.IdTipoDocumento);
                if (item.IdClasificacionTMINinoExpuesto > 0)
                    item.ClasificacionTMINinoExpuesto = utilService.GetParametricaById(item.IdClasificacionTMINinoExpuesto);
            }            

            return data.ToList();
        }

        private List<Reporte5> GetReporte5(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_Reporte5 WHERE IdGestanteControl = @Id";
            var data = connection.Query<Reporte5>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"Reporte5 with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdTipoPrueba > 0)
                    item.TipoPrueba = utilService.GetParametricaById(item.IdTipoPrueba);
                if (item.IdTipoAlimentacionNinoExpuesto > 0)
                    item.TipoAlimentacionNinoExpuesto = utilService.GetParametricaById(item.IdTipoAlimentacionNinoExpuesto);
                if (item.IdSituacionNinoExpuesto > 0)
                    item.SituacionNinoExpuesto = utilService.GetParametricaById(item.IdSituacionNinoExpuesto);
                item.ListParaclinicos = GetParaclinicosNino(connection, item.IdReporte);
            }

            return data.ToList();
        }

        //Get ParaclinicoNino
        private List<ParaclinicoNino> GetParaclinicosNino(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM VIH_ParaclinicoNino WHERE IdReporte = @Id";
            var data = connection.Query<ParaclinicoNino>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"ParaclinicoNino with IdReporte5 {id} not was found");
                return [];
            }

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (item.IdParaclinicoRealizado > 0)
                        item.ParaclinicoRealizado = utilService.GetParametricaById(item.IdParaclinicoRealizado);
                }
                return data.ToList();
            }
            return [];
        }        
    }
}
