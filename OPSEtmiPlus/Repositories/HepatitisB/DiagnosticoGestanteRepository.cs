using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class DiagnosticoGestanteRepository: IDiagnosticoGestanteRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<DiagnosticoGestanteController> _logger;

        public DiagnosticoGestanteRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<DiagnosticoGestanteController>)logger;
        }

        public DiagnosticoGestanteHB CreateDiagnosticoGestante(int id, DiagnosticoGestanteHB reporte)
        {
            _logger.LogInformation($"Executing repository DiagnosticoGestante to CreateDiagnosticoGestante");

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
                    string query = @"INSERT INTO HB_DiagnosticoGestante 
                        (IdGestanteControl, IdMomentoDiagnostico, EdadGestacional, FechaResultadoReactivo, 
                         ResultadoAntiHBcIgM, FechaResultadoAntiHBcIgM, ResultadoAntiHBcTotalOlgG, 
                         FechaResultadoAntiHBcTotalOlgG, ResultadoAntiHBeAg, FechaResultadoAntiHBeAg, 
                         ResultadoAntigenoCargaViral, FechaResultadoCargaViral)
                    OUTPUT INSERTED.IdDiagnosticoGestante
                    VALUES (@IdGestanteControl, @IdMomentoDiagnostico, @EdadGestacional, 
                            @FechaResultadoReactivo, @ResultadoAntiHBcIgM, @FechaResultadoAntiHBcIgM, 
                            @ResultadoAntiHBcTotalOlgG, @FechaResultadoAntiHBcTotalOlgG, 
                            @ResultadoAntiHBeAg, @FechaResultadoAntiHBeAg, @ResultadoAntigenoCargaViral, 
                            @FechaResultadoCargaViral)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoGestante {reporte} not was created");
                        throw new Exception($"DiagnosticoGestante {reporte} not was created");
                    }

                    reporte.IdDiagnosticoGestante = idInserted;
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
