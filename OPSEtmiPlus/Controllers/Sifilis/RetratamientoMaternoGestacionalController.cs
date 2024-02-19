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
    [Route("api/GestanteControl/TratamientoMaternoEstadioClinico/{idTratamientoMaternoEstadioClinico}/Sifilis/[controller]")]
    [ApiController]
    public class RetratamientoMaternoGestacionalController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/TratamientoMaternoEstadioClinico/5/Sifilis/<RetratamientoMaternoGestacionalController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<RetratamientoMaternoGestacionalController> logger, int idTratamientoMaternoEstadioClinico, [FromBody] RetratamientoMaternoGestacional model)
        {
            logger.LogInformation("Executing Create RetratamientoMaternoGestacional");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IRetratamientoMaternoGestacionalRepository repository = new RetratamientoMaternoGestacionalRepository(logger, connectionString);

            try
            {
                var data = repository.CreateRetratamientoMaternoGestacional(idTratamientoMaternoEstadioClinico, model);
                var response = new ApiResponse<RetratamientoMaternoGestacional>(true, Messages.SuccessExecApi, data);
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
