using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public class GestanteControlRepository: IGestanteControlRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<GestanteControlController> _logger;

        public GestanteControlRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<GestanteControlController>)logger;
        }

        public ControlEstadoFichas GetEstadoFichas(int id)
        {
            _logger.LogInformation($"Executing repository ControlEstadoFichas to GetEstadoFichas {id}");

            var model = new ControlEstadoFichas();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    model.TieneFichaVIH = GetExistFicha(connection, "VIH_Reporte1", id);
                    model.TieneFichaSifilis = GetExistFicha(connection, "Sifilis_DiagnosticoMaterno", id);
                    model.TieneFichaHepatitisB = GetExistFicha(connection, "HB_DiagnosticoGestante", id);
                    model.TieneFichaChagas = GetExistFicha(connection, "Chagas_DiagnosticoGestante", id);
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<GestanteControl> GetGestanteControlByIdGestante(int id)
        {
            _logger.LogInformation($"Executing repository GestanteControl to GetGestanteControlByIdGestante {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM GestanteControl WHERE IdGestante = @Id";
                    var data = connection.Query<GestanteControl>(query, new { Id = id }).ToList();

                    if (data == null)
                    {
                        _logger.LogInformation($"Table GestanteControl is empty");
                        throw new Exception($"Table GestanteControl is empty");
                    }

                    foreach (var item in data)
                    {
                        item.ControlEstadoFichas = GetEstadoFichas(item.IdGestanteControl);
                    }

                    return data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public GestanteControl CreateGestanteControl(int id, GestanteControl reporte)
        {
            _logger.LogInformation($"Executing repository GestanteControl to CreateGestanteControl");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Get gestante if exist
                    string queryExist = "SELECT IdGestante FROM Gestante WHERE IdGestante = @Id";
                    Gestante gestanteExist = connection.QueryFirstOrDefault<Gestante>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Gestante {id} not was found");
                        throw new Exception($"Gestante {id} not was found");
                    }

                    //Assign IdGestante
                    reporte.IdGestante = id;

                    //Execute insert
                    string query = @"INSERT INTO GestanteControl 
                        (IdGestante, FechaControl)
                    OUTPUT INSERTED.IdGestanteControl
                    VALUES (@IdGestante, @FechaControl)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"GestanteControl {reporte} not was created");
                        throw new Exception($"GestanteControl {reporte} not was created");
                    }

                    reporte.IdGestanteControl = idInserted;
                    return reporte;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    
        private bool GetExistFicha(SqlConnection connection, string table, int id)
        {
            if (id < 0) return false;

            string query = "SELECT count(*) FROM " + table + " WHERE IdGestanteControl = @Id";
            var data = connection.ExecuteScalar<int>(query, new { Id = id });

            if (data <= 0)
            {
                _logger.LogInformation($"GetExistFicha with IdGestanteControl {id} not was found");
                return false;
            }

            return true;                      
        }
    }
}
