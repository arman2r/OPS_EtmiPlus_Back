using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class Reporte2Repository : IReporte2Repository
    {
        private readonly string? _connectionString;
        private readonly ILogger<Reporte2Controller> _logger;

        public Reporte2Repository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<Reporte2Controller>)logger;
        }

        public Reporte2 CreateReporte2(int id, Reporte2 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte1 to CreateReporte2");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdGestanteControl FROM GestanteControl WHERE IdGestanteControl = @Id";
                    GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"GestanteControl {id} not was found");
                        throw new Exception($"GestanteControl {id} not was found");
                    }

                    //Assign Id
                    reporte.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO VIH_Reporte2 
                        (IdGestanteControl, TieneCargaViral, FechaResultado, ResultadoCargaViral)
                    OUTPUT INSERTED.IdReporte
                    VALUES (@IdGestanteControl, @TieneCargaViral, @FechaResultado, @ResultadoCargaViral)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Reporte2 {reporte} not was created");
                        throw new Exception($"Reporte2 {reporte} not was created");
                    }

                    reporte.IdReporte = idInserted;
                    return reporte;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Reporte2 UpdateReporte2(int id, Reporte2 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte2 to UpdateReporte2");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdReporte FROM VIH_Reporte2 WHERE IdReporte = @Id";
                    Reporte2 gestanteExist = connection.QueryFirstOrDefault<Reporte2>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Reporte2 {id} not was found");
                        throw new Exception($"Reporte2 {id} not was found");
                    }

                    //Assign Id
                    reporte.IdReporte = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_Reporte2
                        SET
                            IdGestanteControl = @IdGestanteControl,
                            TieneCargaViral = @TieneCargaViral,
                            FechaResultado = @FechaResultado,
                            ResultadoCargaViral = @ResultadoCargaViral
                        WHERE
                            IdReporte = @IdReporte";
                    int affectedRows = connection.Execute(updateQuery, reporte);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Reporte2 {reporte.IdReporte} not was updated");
                        throw new Exception($"Reporte2 {reporte.IdReporte} not was updated");
                    }

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
