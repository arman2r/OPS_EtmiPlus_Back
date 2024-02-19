using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.HepatitisB;
using Dapper;
using OPSEtmiPlus.Controllers.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class SeguimientoNinoExpuestoRepository: ISeguimientoNinoExpuestoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SeguimientoNinoExpuestoController> _logger;

        public SeguimientoNinoExpuestoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SeguimientoNinoExpuestoController>)logger;
        }

        public SeguimientoNinoExpuestoHB CreateSeguimientoNinoExpuesto(int id, SeguimientoNinoExpuestoHB reporte)
        {
            _logger.LogInformation($"Executing repository SeguimientoNinoExpuesto to CreateSeguimientoNinoExpuesto");

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
                    string query = @"INSERT INTO HB_SeguimientoNinoExpuesto 
                        (IdGestanteControl, IdCondicionRecienNacido, EdadGestacionalNacimientoSemanas, 
                         IdTipoParto, IdNumeroProductosNacimiento, FechaParto, IdSexo, IdTipoRegimenSalud, 
                         NombreAseguradora, DireccionTerritorial, NombresApellidos, IdTipoDocumento, 
                         NumeroIdentificacion, AplicaronDosisVacunaRecienNacido, IdTiempoAplicacionVacuna, 
                         AplicaronInmunoglobulinaRecienNacido, IdTiempoAplicacionInmonoglobulina)
                    OUTPUT INSERTED.IdSeguimientoNinoExpuesto
                    VALUES (@IdGestanteControl, @IdCondicionRecienNacido, @EdadGestacionalNacimientoSemanas, 
                            @IdTipoParto, @IdNumeroProductosNacimiento, @FechaParto, @IdSexo, @IdTipoRegimenSalud, 
                            @NombreAseguradora, @DireccionTerritorial, @NombresApellidos, @IdTipoDocumento, 
                            @NumeroIdentificacion, @AplicaronDosisVacunaRecienNacido, @IdTiempoAplicacionVacuna, 
                            @AplicaronInmunoglobulinaRecienNacido, @IdTiempoAplicacionInmonoglobulina)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"SeguimientoNinoExpuesto {reporte} not was created");
                        throw new Exception($"SeguimientoNinoExpuesto {reporte} not was created");
                    }

                    reporte.IdSeguimientoNinoExpuesto = idInserted;
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
