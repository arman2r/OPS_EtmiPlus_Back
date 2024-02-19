using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB.DTOs;
using OPSEtmiPlus.Repositories.HepatitisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/[controller]")]
    [ApiController]
    public class HepatitisBController : ControllerBase
    {
        // GET api/<HepatitisBController>/5
        //[Authorize]
        [HttpGet("{idGestanteControl}")]
        public IActionResult Get(ILogger<HepatitisBController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get Data VIHCompleto by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IHepatitisBRepository repository = new HepatitisBRepository(logger, connectionString);

            try
            {
                var data = repository.GetHepatitisBCompleto(idGestanteControl);
                var response = new ApiResponse<HepatitisBCompleto>(true, Messages.SuccessExecApi, data);
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
