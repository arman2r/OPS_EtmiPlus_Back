using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories;
using OPSEtmiPlus.Repositories.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers
{
    [Route("api/GestanteControl/{idGestanteControl}/[controller]")]
    [ApiController]
    public class ReporteEAPBController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET api/GestanteControl/5/<ReporteEAPBController>
        [Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<ReporteEAPBController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get ReporteEAPB by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporteEAPBRepository repository = new ReporteEAPBRepository(logger, connectionString);

            try
            {
                var data = repository.GetByIdGestanteControl(idGestanteControl);
                var response = new ApiResponse<ReporteEAPB>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/GestanteControl/5/<ReporteEAPBController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<ReporteEAPBController> logger, int idGestanteControl, [FromBody] ReporteEAPB model)
        {
            logger.LogInformation("Executing Create Reporte4");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporteEAPBRepository repository = new ReporteEAPBRepository(logger, connectionString);

            try
            {
                var data = repository.CreateReporteEAPB(idGestanteControl, model);
                var response = new ApiResponse<ReporteEAPB>(true, Messages.SuccessExecApi, data);
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
