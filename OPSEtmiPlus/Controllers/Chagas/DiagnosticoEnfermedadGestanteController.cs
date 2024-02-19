using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories.Chagas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/GestanteControl/{idGestanteControl}/Chagas/[controller]")]
    [ApiController]
    public class DiagnosticoEnfermedadGestanteController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/Chagas/<DiagnosticoGestanteController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<DiagnosticoEnfermedadGestanteController> logger, int idGestanteControl, [FromBody] DiagnosticoEnfermedadGestanteChagas model)
        {
            logger.LogInformation("Executing Create DiagnosticoGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IDiagnosticoEnfermedadGestanteRepository repository = new DiagnosticoEnfermedadGestanteRepository(logger, connectionString);

            try
            {
                var data = repository.CreateDiagnosticoGestante(idGestanteControl, model);
                var response = new ApiResponse<DiagnosticoEnfermedadGestanteChagas>(true, Messages.SuccessExecApi, data);
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