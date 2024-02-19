using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class SeguimientoNinoPrimerAnioRepository: ISeguimientoNinoPrimerAnioRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SeguimientoNinoPrimerAnioController> _logger;

        public SeguimientoNinoPrimerAnioRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SeguimientoNinoPrimerAnioController>)logger;
        }

        public SeguimientoNinoPrimerAnio CreateSeguimientoNinoPrimerAnio(int id, SeguimientoNinoPrimerAnio model)
        {
            _logger.LogInformation($"Executing repository SeguimientoNinoPrimerAnio to CreateSeguimientoNinoPrimerAnio");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Get gestante if exist
                    string queryExist = "SELECT IdDiagnosticoEIntervencionNino FROM Sifilis_DiagnosticoEIntervencionNino WHERE IdDiagnosticoEIntervencionNino = @Id";
                    DiagnosticoEIntervencionNino idExist = connection.QueryFirstOrDefault<DiagnosticoEIntervencionNino>(queryExist, new { Id = id })!;

                    if (idExist == null)
                    {
                        _logger.LogInformation($"DiagnosticoEIntervencionNino {id} not was found");
                        throw new Exception($"DiagnosticoEIntervencionNino {id} not was found");
                    }

                    //Assign IdGestante
                    model.IdDiagnosticoEIntervencionNino = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_SeguimientoNinoPrimerAnio 
                        (IdDiagnosticoEIntervencionNino, SeRealizoSeguimiento, IdTipoPruebaNoTreponemica, 
                         FechaResultado, IdDilucionesPruebaNoTreponemica, CumpleCriteriosCuracion)
                        OUTPUT INSERTED.IdSeguimientoNinoPrimerAnio
                    VALUES (@IdDiagnosticoEIntervencionNino, @SeRealizoSeguimiento, @IdTipoPruebaNoTreponemica, 
                            @FechaResultado, @IdDilucionesPruebaNoTreponemica, @CumpleCriteriosCuracion)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoEIntervencionNino {model} not was created");
                        throw new Exception($"DiagnosticoEIntervencionNino {model} not was created");
                    }

                    model.IdSeguimientoNinoPrimerAnio = idInserted;
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
