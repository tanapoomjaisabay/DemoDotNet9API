using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIHelperLIB.Models;
using APIHelperLIB.Services;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Tests.StubServices
{
    internal class HttpConnectServiceStub : IHttpConnectService
    {
        public string GetAPI(HttpParameterModel request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAPIAsync(HttpParameterModel request)
        {
            throw new NotImplementedException();
        }

        public string PostAPI(HttpParameterModel request)
        {
            if (request.controller == "GeneralInfo/GetCustomerData")
            {
                var body = request.jsonData.ToMyModel<RequestGeneralInfoModel>();
                if (body.customerNumber == "1000000001")
                {
                    return "{\"data\":{\"fullName\":\"Tanapoom Jaisabay\",\"idKey\":1,\"customerNumber\":\"1000000001\",\"idCardNumber\":\"1639800146777\",\"nameTH\":\"??????\",\"surnameTH\":\"??????\",\"nameEN\":\"Tanapoom\",\"surnameEN\":\"Jaisabay\",\"birthDate\":\"2025-04-16T00:00:00\",\"gender\":\"M\",\"mobileNumber\":\"0801192777\",\"email\":\"test@gmail.com\",\"status\":\"A\",\"updateBy\":null,\"updateDatetime\":null,\"createBy\":\"ITDEV\",\"createDatetime\":\"2025-04-16T07:29:29.81\"},\"status\":200,\"success\":true,\"message\":\"\",\"error\":null}";
                }
                else if (body.customerNumber == "1000000901")
                {
                    return "{\"data\":null,\"status\":500,\"success\":false,\"message\":\"\",\"error\":null}";
                }
                else
                {
                    return "{\"data\":null,\"status\":200,\"success\":true,\"message\":\"\",\"error\":null}";
                }
            }
            else
            {
                return "";
            }
        }

        public Task<string> PostAPIAsync(HttpParameterModel request)
        {
            throw new NotImplementedException();
        }
    }
}
