using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.Sifilis.DTOs;
using OPSEtmiPlus.Repositories.Sifilis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Sifilis
{
    [Route("api/[controller]")]
    [ApiController]
    public class SifilisController : ControllerBase
    {
        // GET api/<SifilisController>/5
        [Authorize]
        [HttpGet("{idGestanteControl}")]
        public IActionResult Get(ILogger<SifilisController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get Data ChagasCompleto by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISifilisRepository repository = new SifilisRepository(logger, connectionString);

            try
            {
                var data = repository.GetSifilisCompleto(idGestanteControl);
                var response = new ApiResponse<SifilisCompleto>(true, Messages.SuccessExecApi, data);
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
