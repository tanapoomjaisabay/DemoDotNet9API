using APIHelperLIB.Models;
using APIHelperLIB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ResponseModel Status()
        {
            return new ResponseModel
            {
                status = 200,
                success = true,
                message = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToText(),
                error = DateTime.Now
            };
        }
    }
}
