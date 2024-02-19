using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Repositories;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;

namespace OPSEtmiPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametricaController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET: api/<ParametricaController>/5
        //[Authorize]
        [HttpGet("{Id}")]
        public IActionResult Get(ILogger<ParametricaController> logger, int Id)
        {
            logger.LogInformation("Executing Get Parametrica By Id");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParametricaRepository repository = new ParametricaRepository(logger, connectionString);

            try
            {
                var data = repository.GetParametricasById(Id);
                var response = new ApiResponse<Parametrica>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // GET: api/<ParametricaController>/NACIONALIDAD
        //[Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<ParametricaController> logger, string Nombre)
        {
            logger.LogInformation("Executing Get All Parametricas By Nombre");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParametricaRepository repository = new ParametricaRepository(logger, connectionString);

            try
            {
                var data = repository.GetParametricasByName(Nombre);
                var response = new ApiResponse<List<Parametrica>>(true, Messages.SuccessExecApi, data);
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
