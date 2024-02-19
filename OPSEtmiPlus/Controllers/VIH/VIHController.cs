using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using OPSEtmiPlus.Repositories.VIH;
using OPSEtmiPlus.Models.VIH.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.VIH
{
    [Route("api/[controller]")]
    [ApiController]
    public class VIHController : ControllerBase
    {
        // GET api/<VIHController>/5
        //[Authorize]
        [HttpGet("{idGestanteControl}")]
        public IActionResult Get(ILogger<VIHController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get Data VIHCompleto by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IVIHRepository repository = new VIHRepository(logger, connectionString);

            try
            {
                var data = repository.GetVIHCompleto(idGestanteControl);
                var response = new ApiResponse<VIHCompleto>(true, Messages.SuccessExecApi, data);
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
