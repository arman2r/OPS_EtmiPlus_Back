using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public class ReporteBinomioRepository : IReporteBinomioRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ReporteBinomioController> _logger;

        public ReporteBinomioRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ReporteBinomioController>)logger;
        }

        public ReporteBinomio GetByIdGestanteControl(int id)
        {
            _logger.LogInformation("Executing repository ReporteBinomio to GetByIdGestanteControl");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM ReporteBinomio WHERE IdGestanteControl = @Id";
                    var data = connection.QueryFirstOrDefault<ReporteBinomio>(query, new { Id = id });

                    if (data == null)
                    {
                        _logger.LogInformation($"ReporteBinomio with IdGestanteControl {id} not was found");
                        throw new Exception($"ReporteBinomio with IdGestanteControl {id} not was found");
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

        public ReporteBinomio CreateReporteBinomio(int id, ReporteBinomio reporte)
        {
            _logger.LogInformation($"Executing repository ReporteBinomio to CreateReporteBinomio");

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
                    string query = @"INSERT INTO ReporteBinomio (IdGestante, NombreIPSAtencionVIH, NombreRemitenteInformacion,                       CargoRemitenteInformacion, TelefonoRemitenteInformacion, CorreoRemitenteInformacion1,                                        CorreoRemitenteInformacion2)
                    OUTPUT INSERTED.IdBinomio
                    VALUES (@IdGestante, @NombreIPSAtencionVIH, @NombreRemitenteInformacion, @CargoRemitenteInformacion,                     @TelefonoRemitenteInformacion, @CorreoRemitenteInformacion1, @CorreoRemitenteInformacion2)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"ReporteBinomio {reporte} not was created");
                        throw new Exception($"ReporteBinomio {reporte} not was created");
                    }

                    reporte.IdBinomio = idInserted;
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
