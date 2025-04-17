using System.ComponentModel.DataAnnotations;
using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using System.Text.Json;

namespace CustomerAPI.Services
{
    public class GeneralInfoService : IGeneralInfoService
    {
        private readonly IDataService dataService;

        public GeneralInfoService(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public ResponseCustomerInfoModel GetCustomerInformation(RequestGeneralInfoModel model)
        {
            string errorMessage = "Failed get customer infomation. Please try again.";

            try
            {
                ResultCustomerInfoModel data = dataService.Get_CustomerInfomation_By_CustNumber(model.customerNumber);
                data.fullName = GetFullNameCustomer(data);

                return new ResponseCustomerInfoModel
                {
                    status = 200,
                    success = true,
                    data = data
                };
            }
            catch (Exception ex)
            {
                return new ResponseCustomerInfoModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.Message
                };
            }
        }

        private string GetFullNameCustomer(ResultCustomerInfoModel data)
        {
            return data.nameEN + " " + data.surnameEN;
        }
    }
}
