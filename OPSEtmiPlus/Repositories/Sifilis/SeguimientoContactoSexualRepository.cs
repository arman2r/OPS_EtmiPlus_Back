using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class SeguimientoContactoSexualRepository: ISeguimientoContactoSexualRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SeguimientoContactoSexualController> _logger;

        public SeguimientoContactoSexualRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SeguimientoContactoSexualController>)logger;
        }

        public SeguimientoContactoSexual CreateSeguimientoContactoSexual(int id, SeguimientoContactoSexual model)
        {
            _logger.LogInformation($"Executing repository SeguimientoContactoSexual to CreateSeguimientoContactoSexual");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Get gestante if exist
                    string queryExist = "SELECT IdGestanteControl FROM GestanteControl WHERE IdGestanteControl = @Id";
                    GestanteControl idExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = id })!;

                    if (idExist == null)
                    {
                        _logger.LogInformation($"Gestante {id} not was found");
                        throw new Exception($"Gestante {id} not was found");
                    }

                    //Assign IdGestante
                    model.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_SeguimientoContactoSexual
                        (IdGestanteControl, SeNotifico, SeRealizoTratamiento, SeAplicoPenicilinaBenzatinica, IdDosisPenicilinaBenzatinica, FechaAplicacionPenicilinaBenzatinica, NombreMedicamentoDiferentePenicilinaBenzatinica)
                    OUTPUT INSERTED.IdSeguimientoContactoSexual
                    VALUES
                        (@IdGestanteControl, @SeNotifico, @SeRealizoTratamiento, @SeAplicoPenicilinaBenzatinica, @IdDosisPenicilinaBenzatinica, @FechaAplicacionPenicilinaBenzatinica, @NombreMedicamentoDiferentePenicilinaBenzatinica)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"SeguimientoContactoSexual {model} not was created");
                        throw new Exception($"SeguimientoContactoSexual {model} not was created");
                    }

                    model.IdSeguimientoContactoSexual = idInserted;
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
