using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Tests.StubServices;
using Microsoft.Extensions.Configuration;

namespace AuthenticationAPI.Tests.ServiceTests
{
    public class CustomerServiceTest
    {
        private readonly CustomerService service;
        private readonly AppSettingStub appSetting;
        private readonly IConfigurationRoot config;

        public CustomerServiceTest()
        {
            appSetting = new AppSettingStub();
            config = new ConfigurationBuilder()
            .AddInMemoryCollection(appSetting.LoadAppSetting())
            .Build();
            service = new CustomerService(config, new HttpConnectServiceStub());
        }

        [Fact]
        public void Case001_GetCustomerInformation_Success()
        {
            UserIdentityModel model = new UserIdentityModel
            {
                customerNumber = "1000000001"
            };

            var response = service.GetCustomerInformation(model, "UNITTEST");

            Assert.Equal("0801192777", response.mobileNumber);
            Assert.Equal("1639800146777", response.idCardNumber);
        }

        [Fact]
        public void Case002_GetCustomerInformation_Error_Internal()
        {
            UserIdentityModel model = new UserIdentityModel
            {
                customerNumber = "1000000901"
            };

            bool result = true;
            try
            {
                var response = service.GetCustomerInformation(model, "UNITTEST");
            }
            catch (Exception)
            {
                result = false;
            }

            Assert.False(result);
        }

        [Fact]
        public void Case003_GetCustomerInformation_Error_NoData()
        {
            UserIdentityModel model = new UserIdentityModel
            {
                customerNumber = "1000000999"
            };

            bool result = true;
            try
            {
                var response = service.GetCustomerInformation(model, "UNITTEST");
            }
            catch (Exception)
            {
                result = false;
            }

            Assert.False(result);
        }
    }
}
