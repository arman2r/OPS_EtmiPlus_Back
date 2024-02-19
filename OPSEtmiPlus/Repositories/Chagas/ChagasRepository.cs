using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models.Chagas.DTOs;
using OPSEtmiPlus.Models.VIH.DTOs;
using OPSEtmiPlus.Models.VIH;
using Dapper;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Services;
using System.Reflection;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class ChagasRepository : IChagasRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ChagasController> _logger;

        public ChagasRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ChagasController>)logger;
        }

        public ChagasCompleto GetChagasCompleto(int id)
        {
            _logger.LogInformation($"Executing repository ChagasCompleto to GetChagasCompleto {id}");

            var model = new ChagasCompleto();
            model.IdGestanteControl = id;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    #region Gestante
                    //Get DiagnosticoEnfermedadGestanteChagas
                    model.DiagnosticoCompletoGestante = GetDiagnosticoEnfermedadGestante(connection, id);                    
                    #endregion

                    #region Nino
                    //Get GetDiagnosticoNinoExpuestoChagas
                    model.DiagnosticoNinoExpuestoChagas = GetDiagnosticoNinoExpuestoChagas(connection, id);
                    #endregion

                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        #region Gestante
        //Get Gestante
        private List<DiagnosticoEnfermedadGestanteChagas> GetDiagnosticoEnfermedadGestante(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_DiagnosticoGestante WHERE IdGestanteControl = @Id";
            var data = connection.Query<DiagnosticoEnfermedadGestanteChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"DiagnosticoEnfermedadGestanteChagas with IdGestanteControl {id} not was found");
                return [];
            }

            foreach ( var item in data)
            {
                item.CondicionDiagnoticoChagas = utilService.GetParametricaById(item.IdCondicionDiagnosticoChagas);
                item.AlgoritmoChagas = GetAlgoritmos(connection, item.IdDiagnosticoGestante);
            }
            
            return data.ToList();
        }

        //Get AlgoritmoChagas
        private List<AlgoritmoChagas> GetAlgoritmos(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_Algoritmo WHERE IdDiagnosticoGestante = @Id";
            var data = connection.Query<AlgoritmoChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"AlgoritmoChagas with IdDiagnosticoGestante {id} not was found");
                return [];
            }
            else
            {
                foreach (var item in data)
                {
                    if (item.IdExamenParasitologico > 0)
                        item.ExamenParasitologico = utilService.GetParametricaById(item.IdExamenParasitologico);
                    if (item.IdAlgoritmo > 0)
                        item.TratamientosMaternoChagas = GetTratamientosMaterno(connection, item.IdAlgoritmo);
                }                
            }
            return data.ToList();
        }

        //Get List TratamientoMaternoChagas
        private List<TratamientoMaternoChagas> GetTratamientosMaterno(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_TratamientoMaterno WHERE IdAlgoritmo = @Id";
            var data = connection.Query<TratamientoMaternoChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"TratamientoMaternoChagas with IdAlgoritmo {id} not was found");
                return [];
            }

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (item.IdNufurtimoxControlesMedicos > 0)
                        item.NufurtimoxControlesMedicos = utilService.GetParametricaById(item.IdNufurtimoxControlesMedicos);
                }
                return data.ToList();
            }
            return [];
        }
        #endregion

        #region Nino
        //Get Nino
        private List<DiagnosticoNinoExpuestoChagas> GetDiagnosticoNinoExpuestoChagas(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_DiagnosticoNinoExpuesto WHERE IdGestanteControl = @Id";
            var data = connection.Query<DiagnosticoNinoExpuestoChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"DiagnosticoNinoExpuestoChagas with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdExamenParasitologico > 0)
                    item.ExamenParasitologico = utilService.GetParametricaById(item.IdExamenParasitologico);
                item.SeguimientoNinoExpuestoChagas = GetSeguimientoNinoExpuestoChagas(connection, item.IdDiagnosticoNinoExpuesto);
            }
            return data.ToList();
        }

        //Get Seguimiento
        private List<SeguimientoNinoExpuestoChagas> GetSeguimientoNinoExpuestoChagas(SqlConnection connection, int id) 
        { 
           if (id< 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_SeguimientoNinoExpuesto WHERE IdDiagnosticoNinoExpuesto = @Id";
            var data = connection.Query<SeguimientoNinoExpuestoChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SeguimientoNinoExpuestoChagas with IdDiagnosticoNinoExpuesto {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdCondicionRecienNacido > 0)
                    item.CondicionRecienNacido = utilService.GetParametricaById(item.IdCondicionRecienNacido);
                if (item.IdNumeroProductosNacimiento > 0)
                    item.NumeroProductosNacimiento = utilService.GetParametricaById(item.IdNumeroProductosNacimiento);
                if (item.IdSexo > 0)
                    item.Sexo = utilService.GetParametricaById(item.IdSexo);
                if (item.IdTipoParto > 0)
                    item.TipoParto = utilService.GetParametricaById(item.IdTipoParto);
                if (item.IdTipoRegimenSalud > 0)
                    item.TipoRegimenSalud = utilService.GetParametricaById(item.IdTipoRegimenSalud);
                if (item.IdTipoDocumento > 0)
                    item.TipoDocumento = utilService.GetParametricaById(item.IdTipoDocumento);
                item.TratamientosSeguimientoNinoChagas = GetTratamientoSeguimientoNinoChagas(connection, item.IdSeguimientoNinoExpuesto);        
            }

            return data.ToList();
        }

        //Get TratamientoSeguimientoNinoChagas
        private List<TratamientoSeguimientoNinoChagas> GetTratamientoSeguimientoNinoChagas(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM Chagas_TratamientoSeguimientoNino WHERE IdSeguimientoNinoExpuesto = @Id";
            var data = connection.Query<TratamientoSeguimientoNinoChagas>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"TratamientoSeguimientoNinoChagas with IdSeguimientoNinoExpuesto {id} not was found");
                return [];
            }

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (item.IdNufurtimoxControlesMedicos > 0)
                        item.NufurtimoxControlesMedicos = utilService.GetParametricaById(item.IdNufurtimoxControlesMedicos);
                }
                return data.ToList();
            }
            return [];
        }
        #endregion
    }
}
