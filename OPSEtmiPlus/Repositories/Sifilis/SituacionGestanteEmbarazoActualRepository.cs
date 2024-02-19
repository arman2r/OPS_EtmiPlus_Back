using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class SituacionGestanteEmbarazoActualRepository: ISituacionGestanteEmbarazoActualRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SituacionGestanteEmbarazoActualController> _logger;

        public SituacionGestanteEmbarazoActualRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SituacionGestanteEmbarazoActualController>)logger;
        }

        public SituacionGestanteEmbarazoActual CreateSituacionGestanteEmbarazoActual(int id, SituacionGestanteEmbarazoActual situacion)
        {
            _logger.LogInformation($"Executing repository SituacionGestanteEmbarazoActual to CreateSituacionGestanteEmbarazoActual");

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
                    situacion.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_SituacionGestanteEmbarazoActual 
                        (IdGestanteControl, IdSituacionGestante, FechaParto, IdCondicionRecienNacido, IdNumeroProductosNacimiento, 
                         EdadGestacionalNacimientoSemanas, PesoRecienNacidoGramos, IdSexo, IdTipoRegimenSalud, NombreAseguradora, 
                         DireccionTerritorial, NombresApellidos, IdTipoDocumento, NumeroIdentificacion)
                    OUTPUT INSERTED.IdSituacionGestanteEmbarazoActual
                    VALUES (@IdGestanteControl, @IdSituacionGestante, @FechaParto, @IdCondicionRecienNacido, @IdNumeroProductosNacimiento, 
                            @EdadGestacionalNacimientoSemanas, @PesoRecienNacidoGramos, @IdSexo, @IdTipoRegimenSalud, @NombreAseguradora, 
                            @DireccionTerritorial, @NombresApellidos, @IdTipoDocumento, @NumeroIdentificacion)";
                    int idInserted = connection.QuerySingle<int>(query, situacion);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"SituacionGestanteEmbarazoActual {situacion} not was created");
                        throw new Exception($"SituacionGestanteEmbarazoActual {situacion} not was created");
                    }

                    situacion.IdSituacionGestanteEmbarazoActual = idInserted;
                    return situacion;
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
