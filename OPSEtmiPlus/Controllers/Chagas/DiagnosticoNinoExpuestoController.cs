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
    public class DiagnosticoNinoExpuestoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/Chagas/<DiagnosticoNinoExpuestoController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<DiagnosticoNinoExpuestoController> logger, int idGestanteControl, [FromBody] DiagnosticoNinoExpuestoChagas model)
        {
            logger.LogInformation("Executing Create DiagnosticoNinoExpuesto");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IDiagnosticoNinoExpuestoRepository repository = new DiagnosticoNinoExpuestoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateDiagnosticoNinoExpuesto(idGestanteControl, model);
                var response = new ApiResponse<DiagnosticoNinoExpuestoChagas>(true, Messages.SuccessExecApi, data);
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
