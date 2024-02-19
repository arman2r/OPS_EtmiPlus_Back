using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Repositories.Sifilis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Sifilis
{
    [Route("api/GestanteControl/{idGestanteControl}/Sifilis/[controller]")]
    [ApiController]
    public class DiagnosticoMaternoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/Gestante/5/Sifilis/<DiagnosticoMaternoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<DiagnosticoMaternoController> logger, int idGestanteControl, [FromBody] DiagnosticoMaterno model)
        {
            logger.LogInformation("Executing Create DiagnosticoMaterno");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IDiagnosticoMaternoRepository repository = new DiagnosticoMaternoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateDiagnosticoMaterno(idGestanteControl, model);
                var response = new ApiResponse<DiagnosticoMaterno>(true, Messages.SuccessExecApi, data);
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
