using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories;

namespace OPSEtmiPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestanteController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET api/<GestanteController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(ILogger<GestanteController> logger, int id)
        {
            logger.LogInformation("Executing Get Gestante by Id");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteRepository repository = new GestanteRepository(logger, connectionString);

            try
            {
                var data = repository.GetGestanteById(id);
                var response = new ApiResponse<Gestante>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // GET api/<GestanteController>/5
        //[Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<GestanteController> logger, [FromQuery] string? filter, [FromQuery] int page, [FromQuery] int limit)
        {
            logger.LogInformation("Executing Get Gestante by Id");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteRepository repository = new GestanteRepository(logger, connectionString);

            try
            {
                var data = repository.GetGestantes(filter, page, limit);
                var response = new ApiResponse<DataPaginated<Gestante>>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST: api/<GestanteController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<GestanteController> logger, [FromBody] Gestante model)
        {
            logger.LogInformation("Executing Create Gestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteRepository repository = new GestanteRepository(logger, connectionString);

            try
            {
                var data = repository.CreateGestante(model);
                var response = new ApiResponse<Gestante>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST: api/<GestanteController>
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(ILogger<GestanteController> logger, int id, [FromBody] Gestante model)
        {
            logger.LogInformation("Executing Create Gestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IGestanteRepository repository = new GestanteRepository(logger, connectionString);

            try
            {
                var data = repository.UpdateGestante(id, model);
                var response = new ApiResponse<Gestante>(true, Messages.SuccessExecApi, data);
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
