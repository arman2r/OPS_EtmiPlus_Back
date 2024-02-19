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
    public class ReporteBinomioController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET api/GestanteControl/5/<ReporteBinomioController>
        [Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<ReporteBinomioController> logger, int idGestanteControl)
        {
            logger.LogInformation("Executing Get ReporteEAPB by IdGestanteControl");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporteBinomioRepository repository = new ReporteBinomioRepository(logger, connectionString);

            try
            {
                var data = repository.GetByIdGestanteControl(idGestanteControl);
                var response = new ApiResponse<ReporteBinomio>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/GestanteControl/5/<ReporteBinomioController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<ReporteBinomioController> logger, int idGestanteControl, [FromBody] ReporteBinomio model)
        {
            logger.LogInformation("Executing Create ReporteBinomio");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporteBinomioRepository repository = new ReporteBinomioRepository(logger, connectionString);

            try
            {
                var data = repository.CreateReporteBinomio(idGestanteControl, model);
                var response = new ApiResponse<ReporteBinomio>(true, Messages.SuccessExecApi, data);
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
