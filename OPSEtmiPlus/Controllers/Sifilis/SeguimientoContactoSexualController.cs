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
    [Route("api/GestanteControl/{idGestanteControl}/Sifilis/[controller]")]
    [ApiController]
    public class SeguimientoContactoSexualController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/Sifilis/<SeguimientoContactoSexualController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SeguimientoContactoSexualController> logger, int idGestanteControl, [FromBody] SeguimientoContactoSexual model)
        {
            logger.LogInformation("Executing Create SeguimientoContactoSexual");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISeguimientoContactoSexualRepository repository = new SeguimientoContactoSexualRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSeguimientoContactoSexual(idGestanteControl, model);
                var response = new ApiResponse<SeguimientoContactoSexual>(true, Messages.SuccessExecApi, data);
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
