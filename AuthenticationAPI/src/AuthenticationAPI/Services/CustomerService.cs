using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using APIHelperLIB.Models;
using APIHelperLIB.Services;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;

namespace AuthenticationAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration config;
        private readonly IHttpConnectService httpRequest;

        public CustomerService(IConfiguration config, IHttpConnectService httpRequest) 
        {
            this.config = config;
            this.httpRequest = httpRequest;
        }

        public ResultLoginUserPassModel GetCustomerInformation(UserIdentityModel userIdentity, string deviceInfo)
        {
            try
            {
                // test build app

                RequestGeneralInfoModel request = new RequestGeneralInfoModel
                {
                    deviceInfo = deviceInfo,
                    customerNumber = userIdentity.customerNumber
                };

                var response = httpRequest.PostAPI(new HttpParameterModel
                {
                    host = config["CustomerService:URL"].ToText(),
                    controller = "GeneralInfo/GetCustomerData",
                    jsonData = JsonSerializer.Serialize(request),
                    headers = new List<HttpHeaderModel> { new HttpHeaderModel { name = "Authorization", value = "Bearer " + userIdentity.token } }
                });

                var result = response.ToMyModel<ResponseCustomerInfoModel>();
                if (result.status != 200)
                {
                    throw new Exception("Error internal service. " + result.message);
                }
                else if (result.data == null)
                {
                    throw new ValidationException("Data is null.");
                }
                else
                {
                    var custInfo = MapCustomerModel(result.data);
                    custInfo.token = userIdentity.token;
                    return custInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can't get customer information. " + ex.Message);
            }
        }

        private ResultLoginUserPassModel MapCustomerModel (ResultCustomerInfoModel model)
        {
            return new ResultLoginUserPassModel 
            {
                customerNumber = model.customerNumber,
                idCardNumber = model.idCardNumber,
                name = model.fullName,
                birthDate = model.birthDate.ToString("dd/MM/yyyy"),
                gender = model.gender,
                mobileNumber = model.mobileNumber.ToText(),
                customerStatus = "A"
            };
        }
    }
}
