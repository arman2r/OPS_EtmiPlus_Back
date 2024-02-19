using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class SeguimientoSerologicoGestanteRepository: ISeguimientoSerologicoGestanteRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SeguimientoSerologicoGestanteController> _logger;

        public SeguimientoSerologicoGestanteRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SeguimientoSerologicoGestanteController>)logger;
        }

        public SeguimientoSerologicoGestante CreateSeguimientoSerologicoGestante(int id, SeguimientoSerologicoGestante model)
        {
            _logger.LogInformation($"Executing repository SeguimientoSerologicoGestante to CreateSeguimientoSerologicoGestante");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdTratamientoMaternoEstadioClinico FROM Sifilis_TratamientoMaternoEstadioClinico WHERE IdTratamientoMaternoEstadioClinico = @Id";
                    TratamientoMaternoEstadioClinico idExist = connection.QueryFirstOrDefault<TratamientoMaternoEstadioClinico>(queryExist, new { Id = id })!;

                    if (idExist == null)
                    {
                        _logger.LogInformation($"TratamientoMaternoEstadioClinico {id} not was found");
                        throw new Exception($"TratamientoMaternoEstadioClinico {id} not was found");
                    }

                    //Assign Id
                    model.IdTratamientoMaternoEstadioClinico = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_SeguimientoSerologicoGestante 
                        (IdTratamientoMaternoEstadioClinico, IdTipoPruebaNoTreponemicaDuranteGestacion, 
                         FechaResultadoPruebaNoTreponemica, IdDilucionesPruebaNoTreponemicaEsReactiva, 
                         EdadGestacionalRealizacionPruebaNoTreponemica)
                    OUTPUT INSERTED.IdSeguimientoSerologicoGestante
                    VALUES (@IdTratamientoMaternoEstadioClinico, @IdTipoPruebaNoTreponemicaDuranteGestacion, 
                            @FechaResultadoPruebaNoTreponemica, @IdDilucionesPruebaNoTreponemicaEsReactiva, 
                            @EdadGestacionalRealizacionPruebaNoTreponemica)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"SeguimientoSerologicoGestante {model} not was created");
                        throw new Exception($"SeguimientoSerologicoGestante {model} not was created");
                    }

                    model.IdSeguimientoSerologicoGestante = idInserted;
                    return model;
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
