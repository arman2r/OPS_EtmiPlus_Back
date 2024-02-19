using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Repositories.HepatitisB;
using OPSEtmiPlus.Repositories.Sifilis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Sifilis
{
    [Route("api/GestanteControl/{idGestante}/Sifilis/[controller]")]
    [ApiController]
    public class SituacionGestanteEmbarazoActualController : ControllerBase
    {        
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/Sifilis/<SituacionGestanteEmbarazoActualController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SituacionGestanteEmbarazoActualController> logger, int idGestante, [FromBody] SituacionGestanteEmbarazoActual model)
        {
            logger.LogInformation("Executing Create SituacionGestanteEmbarazoActual");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISituacionGestanteEmbarazoActualRepository repository = new SituacionGestanteEmbarazoActualRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSituacionGestanteEmbarazoActual(idGestante, model);
                var response = new ApiResponse<SituacionGestanteEmbarazoActual>(true, Messages.SuccessExecApi, data);
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
