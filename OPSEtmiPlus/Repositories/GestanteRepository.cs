using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Services;
using System.Collections.Generic;

namespace OPSEtmiPlus.Repositories
{
    public class GestanteRepository: IGestanteRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<GestanteController> _logger;

        public GestanteRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<GestanteController>)logger;
        }

        public Gestante GetGestanteById(int id)
        {
            _logger.LogInformation($"Executing repository Gestante to GetGestante {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var utilService = new Util(_logger, _connectionString);

                    string query = "SELECT * FROM Gestante WHERE IdGestante = @Id";
                    var model = connection.QueryFirstOrDefault<Gestante>(query, new { Id = id });

                    if (model == null)
                    {
                        _logger.LogInformation($"Gestante {id} not was found");
                        throw new Exception($"Gestante {id} not was found");
                    }

                    if (model.IdNacionalidad > 0)
                        model.Nacionalidad = utilService.GetParametricaById(model.IdNacionalidad);
                    if (model.IdTipoDocumento > 0)
                        model.TipoDocumento = utilService.GetParametricaById(model.IdTipoDocumento);
                    if (model.IdTipoRegimenSalud > 0)
                        model.TipoRegimenSalud = utilService.GetParametricaById(model.IdTipoRegimenSalud);
                    if (model.IdPertenenciaEtnica > 0)
                        model.PertenenciaEtnica = utilService.GetParametricaById(model.IdPertenenciaEtnica);
                    if (model.IdGrupoPoblacional > 0)
                        model.GrupoPoblacional = utilService.GetParametricaById(model.IdGrupoPoblacional);
                    if (model.IdAreaOcurrencia > 0)
                        model.AreaOcurrencia = utilService.GetParametricaById(model.IdAreaOcurrencia);
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public DataPaginated<Gestante> GetGestantes(string? filter, int page, int limit)
        {
            _logger.LogInformation($"Executing repository Gestante to GetGestantes with filter: {filter}, page: {page}, limit: {limit}");

            try
            {
                if (page <= 0)
                    page = 1;
                if (limit <= 0)
                    limit = 10;

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "";

                    if (filter != null)
                        query = @"SELECT * FROM Gestante 
                            WHERE NumeroDocumento LIKE '%' + @Filter + '%' OR NombresApellidos LIKE '%' + @Filter + '%'
                            ORDER BY NombresApellidos OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
                    else
                        query = @"SELECT * FROM Gestante 
                            ORDER BY NombresApellidos OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";

                    // Calculate offset
                    int offset = (page - 1) * limit;
                    IEnumerable<Gestante> list = connection.Query<Gestante>(query, new { Filter = filter, Offset = offset, Limit = limit });
                   
                    if (list == null)
                    {
                        _logger.LogInformation($"Gestantes not was found");
                        throw new Exception($"Gestantes not was found");
                    }

                    //Get total
                    string queryCount = "SELECT COUNT(*) FROM Gestante";
                    int total = connection.ExecuteScalar<int>(queryCount);

                    var obj = new DataPaginated<Gestante>(total, list.ToList());
                    return obj;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Gestante CreateGestante(Gestante model)
        {
            _logger.LogInformation($"Executing repository Gestante to CreateGestante {model.NombresApellidos}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Execute insert
                    string query = @"INSERT INTO Gestante (NombresApellidos, IdNacionalidad, IdTipoDocumento, NumeroDocumento,
                                        Edad, IdTipoRegimenSalud, NombreAseguradora, IdPertenenciaEtnica,
                                        IdGrupoPoblacional, IdAreaOcurrencia, IdDptoResidencia,
                                        IdMunicipioResidencia, DireccionResidencia, IdDptoAtencion,
                                        IdMunicipioAtencion, Telefono, FechaPosibleParto, SeRealizaControlPrenatal, EdadGestacionalSemanas)
                            OUTPUT INSERTED.IdGestante
                            VALUES (@NombresApellidos, @IdNacionalidad, @IdTipoDocumento, @NumeroDocumento,
                              @Edad, @IdTipoRegimenSalud, @NombreAseguradora, @IdPertenenciaEtnica,
                              @IdGrupoPoblacional, @IdAreaOcurrencia, @IdDptoResidencia,
                              @IdMunicipioResidencia, @DireccionResidencia, @IdDptoAtencion,
                              @IdMunicipioAtencion, @Telefono, @FechaPosibleParto, @SeRealizaControlPrenatal, @EdadGestacionalSemanas)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Gestante {model.NombresApellidos} not was created");
                        throw new Exception($"Gestante {model.NombresApellidos} not was created");
                    }

                    model.IdGestante = idInserted;
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        public Gestante UpdateGestante(int id,  Gestante model)
        {            
            _logger.LogInformation($"Executing repository Gesttante to UpdateGestante {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    if (model.IdGestante != id)
                        throw new Exception($"Gestante {id} not match");

                    //Get user first
                    string queryExist = "SELECT * FROM Gestante WHERE IdGestante = @Id";
                    Gestante gestanteExist = connection.QueryFirstOrDefault<Gestante>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Gestante {id} not was found");
                        throw new Exception($"Gestante {id} not was found");
                    }
                    
                    //Execute update
                    string query = @"UPDATE Gestante 
                           SET NombresApellidos = @NombresApellidos,
                               IdNacionalidad = @IdNacionalidad,
                               IdTipoDocumento = @IdTipoDocumento,
                               NumeroDocumento = @NumeroDocumento,
                               Edad = @Edad,
                               IdTipoRegimenSalud = @IdTipoRegimenSalud,
                               NombreAseguradora = @NombreAseguradora,
                               IdPertenenciaEtnica = @IdPertenenciaEtnica,
                               IdGrupoPoblacional = @IdGrupoPoblacional,
                               IdAreaOcurrencia = @IdAreaOcurrencia,
                               IdDptoResidencia = @IdDptoResidencia,
                               IdMunicipioResidencia = @IdMunicipioResidencia,
                               DireccionResidencia = @DireccionResidencia,
                               IdDptoAtencion = @IdDptoAtencion,
                               IdMunicipioAtencion = @IdMunicipioAtencion,
                               Telefono = @Telefono,
                               FechaPosibleParto = @FechaPosibleParto,
                               SeRealizaControlPrenatal = @SeRealizaControlPrenatal,
                               EdadGestacionalSemanas = @EdadGestacionalSemanas
                           WHERE IdGestante = @IdGestante";
                    int affectedRows = connection.Execute(query, model);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Gestante {id} not was updated");
                        throw new Exception($"Gestante {id} not was updated");
                    }

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
