using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories.Chagas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/GestanteControl/Diagnostico/{idDiagnostico}/Chagas/[controller]")]
    [ApiController]
    public class AlgoritmoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Diagnostico/5/Chagas/<AlgoritmoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<AlgoritmoController> logger, int idDiagnostico, [FromBody] AlgoritmoChagas model)
        {
            logger.LogInformation("Executing Create Algoritmo");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IAlgoritmoRepository repository = new AlgoritmoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateAlgoritmo(idDiagnostico, model);
                var response = new ApiResponse<AlgoritmoChagas>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
