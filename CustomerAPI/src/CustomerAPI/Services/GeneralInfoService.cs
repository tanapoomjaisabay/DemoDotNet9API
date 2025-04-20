using System.ComponentModel.DataAnnotations;
using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using APIHelperLIB.Services;
using Azure;

namespace CustomerAPI.Services
{
    public class GeneralInfoService : IGeneralInfoService
    {
        private readonly ILogger<GeneralInfoService> logger;
        private readonly IDataService dataService;

        public GeneralInfoService(ILogger<GeneralInfoService> logger, IDataService dataService)
        {
            this.logger = logger;
            this.dataService = dataService;
        }

        public ResponseCustomerInfoModel GetCustomerInformation(RequestGeneralInfoModel model)
        {
            string errorMessage = "Failed get customer infomation. Please try again.";
            string logId = Guid.NewGuid().ToString();

            try
            {
                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.customerNumber, "GeneralInfo", "IN", model, ""));

                ResultCustomerInfoModel data = dataService.Get_CustomerInfomation_By_CustNumber(model.customerNumber);
                data.fullName = GetFullNameCustomer(data);

                var response = new ResponseCustomerInfoModel
                {
                    status = 200,
                    success = true,
                    data = data
                };

                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.customerNumber, "GeneralInfo", "OUT", model, ""));
                return response;
            }
            catch (Exception ex)
            {
                var response = new ResponseCustomerInfoModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.ToMessage()
                };

                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.customerNumber, "GeneralInfo", "OUT", model, ex.ToMessage()));
                return response;
            }
        }

        private string GetFullNameCustomer(ResultCustomerInfoModel data)
        {
            return data.nameEN + " " + data.surnameEN;
        }
    }
}
