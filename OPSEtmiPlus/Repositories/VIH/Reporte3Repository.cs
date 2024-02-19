using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class Reporte3Repository : IReporte3Repository
    {
        private readonly string? _connectionString;
        private readonly ILogger<Reporte3Controller> _logger;

        public Reporte3Repository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<Reporte3Controller>)logger;
        }

        public Reporte3 CreateReporte3(int id, Reporte3 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte3 to CreateReporte3");

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
                    string query = @"INSERT INTO VIH_Reporte3 
                        (IdGestanteControl, IdSituacionGestante, FechaDelParto, IdEsquemaAntirretroviralIntraparto, 
                         IdEsquemaArvIntraparto, IdCondicionRecienNacido, IdNumeroDeProductosNacimiento, 
                         EdadGestacionalNacimientoSemanas, PesoRecienNacidoGramos, IdSexo, IdTipoParto, 
                         SeRealizoSuprecionLactancia, MedicamentoSuministrado)
                    OUTPUT INSERTED.IdReporte
                    VALUES (@IdGestanteControl, @IdSituacionGestante, @FechaDelParto, @IdEsquemaAntirretroviralIntraparto, 
                            @IdEsquemaArvIntraparto, @IdCondicionRecienNacido, @IdNumeroDeProductosNacimiento, 
                            @EdadGestacionalNacimientoSemanas, @PesoRecienNacidoGramos, @IdSexo, @IdTipoParto, 
                            @SeRealizoSuprecionLactancia, @MedicamentoSuministrado)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Reporte3 {reporte} not was created");
                        throw new Exception($"Reporte3 {reporte} not was created");
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

        public Reporte3 UpdateReporte3(int id, Reporte3 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte3 to UpdateReporte3");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdReporte FROM VIH_Reporte3 WHERE IdReporte = @Id";
                    Reporte3 gestanteExist = connection.QueryFirstOrDefault<Reporte3>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Reporte3 {id} not was found");
                        throw new Exception($"Reporte3 {id} not was found");
                    }

                    //Assign Id
                    reporte.IdReporte = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_Reporte3
                        SET
                            IdGestanteControl = @IdGestanteControl,
                            IdSituacionGestante = @IdSituacionGestante,
                            FechaDelParto = @FechaDelParto,
                            IdEsquemaAntirretroviralIntraparto = @IdEsquemaAntirretroviralIntraparto,
                            IdEsquemaArvIntraparto = @IdEsquemaArvIntraparto,
                            IdCondicionRecienNacido = @IdCondicionRecienNacido,
                            IdNumeroDeProductosNacimiento = @IdNumeroDeProductosNacimiento,
                            EdadGestacionalNacimientoSemanas = @EdadGestacionalNacimientoSemanas,
                            PesoRecienNacidoGramos = @PesoRecienNacidoGramos,
                            IdSexo = @IdSexo,
                            IdTipoParto = @IdTipoParto,
                            SeRealizoSupresionLactancia = @SeRealizoSupresionLactancia,
                            MedicamentoSuministrado = @MedicamentoSuministrado
                        WHERE
                            IdReporte = @IdReporte";
                    int affectedRows = connection.Execute(updateQuery, reporte);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Reporte3 {reporte.IdReporte} not was updated");
                        throw new Exception($"Reporte3 {reporte.IdReporte} not was updated");
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
