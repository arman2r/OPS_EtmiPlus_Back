using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas.DTOs;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.VIH.DTOs;
using OPSEtmiPlus.Repositories.Chagas;
using OPSEtmiPlus.Repositories.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChagasController : ControllerBase
    {
        // GET api/<ChagasController>/5
        //[Authorize]
        [HttpGet("{idGestanteControl}")]
        public IActionResult Get(ILogger<ChagasController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get Data ChagasCompleto by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IChagasRepository repository = new ChagasRepository(logger, connectionString);

            try
            {
                var data = repository.GetChagasCompleto(idGestanteControl);
                var response = new ApiResponse<ChagasCompleto>(true, Messages.SuccessExecApi, data);
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
