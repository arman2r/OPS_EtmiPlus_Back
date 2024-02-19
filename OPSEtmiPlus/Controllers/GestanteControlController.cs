using DapperTest.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Services;
using OPSEtmiPlus.Repositories;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers
{
    [Route("api/Gestante/{idGestante}/[controller]")]
    [ApiController]
    public class GestanteControlController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET api/Gestante/5/<GestanteControlController>/EstadoFichas
        //[Authorize]
        [HttpGet("EstadoFichas")]
        public IActionResult GetEstadoFichas(ILogger<GestanteControlController> logger, int idGestante)
        {
            logger.LogInformation("Executing Get List GestanteControl by IdGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteControlRepository repository = new GestanteControlRepository(logger, connectionString);

            try
            {
                var data = repository.GetEstadoFichas(idGestante);
                var response = new ApiResponse<ControlEstadoFichas>(true, Messages.SuccessExecApi, data);                
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // GET api/Gestante/5/<GestanteControlController>
        //[Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<GestanteControlController> logger, int idGestante)
        {
            logger.LogInformation("Executing Get List GestanteControl by IdGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteControlRepository repository = new GestanteControlRepository(logger, connectionString);

            try
            {
                var data = repository.GetGestanteControlByIdGestante(idGestante);
                var response = new ApiResponse<List<GestanteControl>>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/Gestante/5/<GestanteControlController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<GestanteControlController> logger, int idGestante, [FromBody] GestanteControl model)
        {
            logger.LogInformation("Executing Get List GestanteControl by IdGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteControlRepository repository = new GestanteControlRepository(logger, connectionString);

            try
            {
                var data = repository.CreateGestanteControl(idGestante, model);
                var response = new ApiResponse<GestanteControl>(true, Messages.SuccessExecApi, data);
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
