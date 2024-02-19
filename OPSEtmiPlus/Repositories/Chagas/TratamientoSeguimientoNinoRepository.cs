using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class TratamientoSeguimientoNinoRepository: ITratamientoSeguimientoNinoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<TratamientoSeguimientoNinoController> _logger;

        public TratamientoSeguimientoNinoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<TratamientoSeguimientoNinoController>)logger;
        }

        public TratamientoSeguimientoNinoChagas CreateTratamientoSeguimientoNino(int id, TratamientoSeguimientoNinoChagas model)
        {
            _logger.LogInformation($"Executing repository TratamientoSeguimientoNino to CreateTratamientoSeguimientoNino");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdSeguimientoNinoExpuesto FROM Chagas_SeguimientoNinoExpuesto WHERE IdSeguimientoNinoExpuesto = @Id";
                    GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"GestanteControl {id} not was found");
                        throw new Exception($"GestanteControl {id} not was found");
                    }

                    //Assign Id
                    model.IdSeguimientoNinoExpuesto = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_TratamientoSeguimientoNino 
                        (IdSeguimientoNinoExpuesto, BenznidazolX60Dias, FechaInicioTratamiento, NufurtimoxX60Dias, 
                         IdNufurtimoxControlesMedicos, EsAntigenosTotales6Meses, EsAntigenosRecombinantes6Meses, 
                         ResultadoPruebaSerologica6Meses, EsAntigenosTotales12Meses, EsAntigenosRecombinantes12Meses, 
                         ResultadoPruebaSerologica12Meses, EsNinoCuradoChagas)
                    OUTPUT INSERTED.IdTratamientoSeguimientoNino
                    VALUES (@IdSeguimientoNinoExpuesto, @BenznidazolX60Dias, @FechaInicioTratamiento, 
                            @NufurtimoxX60Dias, @IdNufurtimoxControlesMedicos, @EsAntigenosTotales6Meses, 
                            @EsAntigenosRecombinantes6Meses, @ResultadoPruebaSerologica6Meses, 
                            @EsAntigenosTotales12Meses, @EsAntigenosRecombinantes12Meses, 
                            @ResultadoPruebaSerologica12Meses, @EsNinoCuradoChagas)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"TratamientoSeguimientoNino {model} not was created");
                        throw new Exception($"TratamientoSeguimientoNino {model} not was created");
                    }

                    model.IdTratamientoSeguimientoNino = idInserted;
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
