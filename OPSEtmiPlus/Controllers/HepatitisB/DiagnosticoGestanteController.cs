using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Repositories.HepatitisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/GestanteControl/{idGestante}/HepatitisB/[controller]")]
    [ApiController]
    public class DiagnosticoGestanteController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/HepatitisB/<DiagnosticoGestanteController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<DiagnosticoGestanteController> logger, int idGestante, [FromBody] DiagnosticoGestanteHB model)
        {
            logger.LogInformation("Executing Create SeguimientoNinoExpuesto");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IDiagnosticoGestanteRepository repository = new DiagnosticoGestanteRepository(logger, connectionString);

            try
            {
                var data = repository.CreateDiagnosticoGestante(idGestante, model);
                var response = new ApiResponse<DiagnosticoGestanteHB>(true, Messages.SuccessExecApi, data);
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
