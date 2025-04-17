using System.Diagnostics;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service) 
        {
            this.service = service;
        }

        [HttpPost]
        public ResponseAuthenModel UserAuthen(RequestUserAuthenModel model)
        {
            model.transactionDate = DateTime.Now;
            return service.Login(model);
        }
    }
}
