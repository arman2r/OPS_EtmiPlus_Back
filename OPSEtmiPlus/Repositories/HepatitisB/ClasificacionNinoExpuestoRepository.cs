using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Controllers.HepatitisB;
using Dapper;
using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class ClasificacionNinoExpuestoRepository: IClasificacionNinoExpuestoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ClasificacionNinoExpuestoController> _logger;

        public ClasificacionNinoExpuestoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ClasificacionNinoExpuestoController>)logger;
        }

        public ClasificacionNinoExpuestoHB CreateClasificacionNinoExpuesto(int id, ClasificacionNinoExpuestoHB reporte)
        {
            _logger.LogInformation($"Executing repository ClasificacionNinoExpuesto to CreateClasificacionNinoExpuesto");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdSeguimientoNinoExpuesto FROM HB_SeguimientoNinoExpuesto WHERE IdSeguimientoNinoExpuesto = @Id";
                    SeguimientoNinoExpuestoHB gestanteExist = connection.QueryFirstOrDefault<SeguimientoNinoExpuestoHB>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"SeguimientoNinoExpuestoHB {id} not was found");
                        throw new Exception($"SeguimientoNinoExpuestoHB {id} not was found");
                    }

                    //Assign Id
                    reporte.IdSeguimientoNinoExpuesto = id;

                    //Execute insert
                    string query = @"INSERT INTO HB_ClasificacionNinoExpuesto 
                        (IdSeguimientoNinoExpuesto, IdResultadoAntiHBsAg, FechaResultadoAntiHBsAg, 
                         IdResultadoAntiHBs, FechaResultadoAntiHBs, IdCondicionFinal, IdClasificacionFinal)
                    OUTPUT INSERTED.IdClasificacionNinoExpuesto
                    VALUES (@IdSeguimientoNinoExpuesto, @IdResultadoAntiHBsAg, @FechaResultadoAntiHBsAg, 
                            @IdResultadoAntiHBs, @FechaResultadoAntiHBs, @IdCondicionFinal, @IdClasificacionFinal)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"ClasificacionNinoExpuesto {reporte} not was created");
                        throw new Exception($"ClasificacionNinoExpuesto {reporte} not was created");
                    }

                    reporte.IdClasificacionNinoExpuesto = idInserted;
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
