using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneralInfoController : ControllerBase
    {
        private readonly IGeneralInfoService service;

        public GeneralInfoController(IGeneralInfoService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize]
        public ResponseCustomerInfoModel GetCustomerData(RequestGeneralInfoModel model)
        {
            model.transactionDate = DateTime.Now;
            return service.GetCustomerInformation(model);
        }
    }
}
