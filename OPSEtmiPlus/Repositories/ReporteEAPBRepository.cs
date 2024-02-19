using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public class ReporteEAPBRepository : IReporteEAPBRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ReporteEAPBController> _logger;

        public ReporteEAPBRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ReporteEAPBController>)logger;
        }

        public ReporteEAPB GetByIdGestanteControl(int id)
        {
            _logger.LogInformation("Executing repository ReporteEAPB to GetByIdGestanteControl");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM ReporteEAPB WHERE IdGestanteControl = @Id";
                    var data = connection.QueryFirstOrDefault<ReporteEAPB>(query, new { Id = id });

                    if (data == null)
                    {
                        _logger.LogInformation($"ReporteEAPB with IdGestanteControl {id} not was found");
                        throw new Exception($"ReporteEAPB with IdGestanteControl {id} not was found");
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

        public ReporteEAPB CreateReporteEAPB(int id, ReporteEAPB reporte)
        {
            _logger.LogInformation($"Executing repository ReporteEAPB to CreateReporteEAPB");

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
                    string query = @"INSERT INTO ReporteEAPB (IdGestante, FechaReporte, NombreEAPB,                             NombreRemitenteInformacion, CargoRemitenteInformacion, TelefonoMovilRemitenteInformacion,             TelefonoFijoRemitenteInformacion, CorreoRemitenteInformacion1, CorreoRemitenteInformacion2)
                    OUTPUT INSERTED.IdReporteEAPB
                    VALUES (@IdGestante, @FechaReporte, @NombreEAPB, @NombreRemitenteInformacion,                                 @CargoRemitenteInformacion, @TelefonoMovilRemitenteInformacion,                                       @TelefonoFijoRemitenteInformacion, @CorreoRemitenteInformacion1, @CorreoRemitenteInformacion2)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Reporte4 {reporte} not was created");
                        throw new Exception($"Reporte4 {reporte} not was created");
                    }

                    reporte.IdReporteEAPB = idInserted;
                    return reporte;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
