using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Auth model)
        {
            var jwtManager = CommonApiHelpers.getAuthManager();
            // Check user in database .......
            //......
            //......

            // To Do
            if (model.Username == "user" && model.Password == "dev123")
            {
                var token = jwtManager.GenerateToken(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
