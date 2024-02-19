using DapperTest.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // GET: api/<UsuarioController>
        /*[Authorize]
        [HttpGet]
        public IActionResult Get(ILogger<UsuarioController> logger)
        {
            logger.LogInformation("Executing Get All Users");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IUserRepository repository = new UsuarioRepository(logger, connectionString);

            try
            {
                var data = repository.GetUsers();
                var response = new ApiResponse<List<Usuario>>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            } catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }*/

        // GET api/<UsuarioController>/5
        /*[Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(ILogger<UsuarioController> logger, int id)
        {
            logger.LogInformation("Executing Get User by Id");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IUserRepository repository = new UsuarioRepository(logger, connectionString);
            
            try
            {
                var data = repository.GetById(id);
                var response = new ApiResponse<Usuario>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }*/

        // POST api/<UsuarioController>
        /*[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<UsuarioController> logger, [FromBody] Usuario model)
        {
            logger.LogInformation("Executing Create User");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IUserRepository repository = new UsuarioRepository(logger, connectionString);

            try
            {
                var data = repository.CreateUser(model);
                var response = new ApiResponse<Usuario>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }*/

        // PUT api/<UsuarioController>/5
        /*[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(ILogger<UsuarioController> logger, int id, [FromBody] Usuario model)
        {
            logger.LogInformation("Executing Update User");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IUserRepository repository = new UsuarioRepository(logger, connectionString);

            try
            {
                var data = repository.UpdateUser(id, model);
                var response = new ApiResponse<Usuario>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }*/

        // DELETE api/<UsuarioController>/5
        /*[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(ILogger<UsuarioController> logger, int id)
        {
            logger.LogInformation("Executing Delete User");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IUserRepository repository = new UsuarioRepository(logger, connectionString);

            try
            {
                var data = repository.DeleteUser(id);
                var response = new ApiResponse<bool>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }*/
    }
}
