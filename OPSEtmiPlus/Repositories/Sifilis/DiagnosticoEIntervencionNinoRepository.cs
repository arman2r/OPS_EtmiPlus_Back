using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;
using System.Reflection;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class DiagnosticoEIntervencionNinoRepository : IDiagnosticoEIntervencionNinoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<DiagnosticoEIntervencionNinoController> _logger;

        public DiagnosticoEIntervencionNinoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<DiagnosticoEIntervencionNinoController>)logger;
        }

        public DiagnosticoEIntervencionNino CreateDiagnosticoEIntervencionNino(int id, DiagnosticoEIntervencionNino model)
        {
            _logger.LogInformation($"Executing repository DiagnosticoEIntervencionNino to CreateDiagnosticoEIntervencionNino");

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
                    model.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_DiagnosticoEIntervencionNino 
                        (IdGestanteControl, EsDiagnosticoDescartado, SeAplicoDosisProfilacticaPenicilinaBenzatinica, 
                         EsConfirmadoSifilisCongenita, SeAplicoTratamiento, RecibioTratamientoDePenicilinaCristalina, 
                         RecibioTratamientoDePenicilinaCristalina10Dias, IdCriterioUtilizado)
                    OUTPUT INSERTED.IdDiagnosticoEIntervencionNino
                    VALUES (@IdGestanteControl, @EsDiagnosticoDescartado, @SeAplicoDosisProfilacticaPenicilinaBenzatinica, 
                            @EsConfirmadoSifilisCongenita, @SeAplicoTratamiento, @RecibioTratamientoDePenicilinaCristalina, 
                            @RecibioTratamientoDePenicilinaCristalina10Dias, @IdCriterioUtilizado)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoEIntervencionNino {model} not was created");
                        throw new Exception($"DiagnosticoEIntervencionNino {model} not was created");
                    }

                    model.IdDiagnosticoEIntervencionNino = idInserted;
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
