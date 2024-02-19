using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class AplicacionPenicilinaBenzatinicaRepository: IAplicacionPenicilinaBenzatinicaRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<AplicacionPenicilinaBenzatinicaController> _logger;

        public AplicacionPenicilinaBenzatinicaRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<AplicacionPenicilinaBenzatinicaController>)logger;
        }

        public AplicacionPenicilinaBenzatinica CreateAplicacionPenicilinaBenzatinica(int? idTratamiento, int? idRetratamiento, int? idSeguimiento, AplicacionPenicilinaBenzatinica model)
        {
            _logger.LogInformation($"Executing repository AplicacionPenicilinaBenzatinica to CreateAplicacionPenicilinaBenzatinica");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations

                    //Validate Tratamiento
                    if (idTratamiento != null)
                    {
                        string queryExist = "SELECT IdTratamientoMaternoEstadioClinico FROM Sifilis_TratamientoMaternoEstadioClinico WHERE IdTratamientoMaternoEstadioClinico = @Id";
                        TratamientoMaternoEstadioClinico gestanteExist = connection.QueryFirstOrDefault<TratamientoMaternoEstadioClinico>(queryExist, new { Id = idTratamiento })!;

                        if (gestanteExist == null)
                        {
                            _logger.LogInformation($"TratamientoMaternoEstadioClinico {idTratamiento} not was found");
                            throw new Exception($"TratamientoMaternoEstadioClinico {idTratamiento} not was found");
                        }

                        //Assign Id
                        model.IdTratamientoMaternoEstadioClinico = idTratamiento ?? null;
                    }

                    //Validate Tratamiento
                    if (idRetratamiento == null)
                    {
                        string queryExist = "SELECT IdRetratamientoMaternoGestacional FROM Sifilis_RetratamientoMaternoGestacional WHERE IdRetratamientoMaternoGestacional = @Id";
                        GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = idRetratamiento })!;

                        if (gestanteExist == null)
                        {
                            _logger.LogInformation($"RetratamientoMaternoGestacional {idRetratamiento} not was found");
                            throw new Exception($"RetratamientoMaternoGestacional {idRetratamiento} not was found");
                        }

                        //Assign Id
                        model.IdRetratamientoMaternoGestacional = idRetratamiento ?? null;
                    }

                    //Validate Tratamiento
                    if (idSeguimiento == null)
                    {
                        string queryExist = "SELECT IdSeguimientoContactoSexual FROM Sifilis_SeguimientoContactoSexual WHERE IdSeguimientoContactoSexual = @Id";
                        GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = idSeguimiento })!;

                        if (gestanteExist == null)
                        {
                            _logger.LogInformation($"SeguimientoContactoSexual {idSeguimiento} not was found");
                            throw new Exception($"SeguimientoContactoSexual {idSeguimiento} not was found");
                        }

                        //Assign Id
                        model.IdSeguimientoContactoSexual = idSeguimiento ?? null;
                    }

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_AplicacionPenicilinaBenzatinica 
                        (IdTratamientoMaternoEstadioClinico, IdRetratamientoMaternoGestacional, IdSeguimientoContactoSexual, 
                        EsRetratamiento, IdDosisPenicilinaBenzatinica, FechaAplicacionPenicilinaBenzatinica, EdadGestionalAplicacionPenicilinaBenzatinicaSemanas)
                    OUTPUT INSERTED.IdAplicacionPenicilinaBenzatinica
                    VALUES 
                        (@IdTratamientoMaternoEstadioClinico, @IdRetratamientoMaternoGestacional, @IdSeguimientoContactoSexual, 
                        @EsRetratamiento, @IdDosisPenicilinaBenzatinica, @FechaAplicacionPenicilinaBenzatinica, @EdadGestionalAplicacionPenicilinaBenzatinicaSemanas)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoMaterno {model} not was created");
                        throw new Exception($"DiagnosticoMaterno {model} not was created");
                    }

                    model.IdAplicacionPenicilinaBenzatinica = idInserted;
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
