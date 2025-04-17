using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerAPI.Models;
using CustomerAPI.Services;
using CustomerAPI.Tests.StubServices;

namespace CustomerAPI.Tests.ServiceTests
{
    public class GeneralInfoServiceTest
    {
        private readonly GeneralInfoService service;

        public GeneralInfoServiceTest()
        {
            service = new GeneralInfoService(new DataServiceStub());
        }

        [Fact]
        public void Case001_GetCustomerInformation_Success()
        {
            RequestGeneralInfoModel model = new RequestGeneralInfoModel 
            {
                customerNumber = "1000000001"
            };

            ResponseCustomerInfoModel result = service.GetCustomerInformation(model);
            
            Assert.Equal("1639800146779", result.data.idCardNumber);
        }

        [Fact]
        public void Case002_GetCustomerInformation_Error()
        {
            RequestGeneralInfoModel model = new RequestGeneralInfoModel
            {
                customerNumber = "9000000001"
            };

            var result = service.GetCustomerInformation(model);

            Assert.Equal(500, result.status);
        }
    }
}
