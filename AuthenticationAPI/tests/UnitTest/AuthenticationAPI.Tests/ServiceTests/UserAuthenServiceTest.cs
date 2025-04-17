using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Tests.StubServices;
using Microsoft.Extensions.Configuration;

namespace AuthenticationAPI.Tests.ServiceTests
{
    public class UserAuthenServiceTest
    {
        private readonly UserAuthenService service;
        private readonly AppSettingStub appSetting;
        private readonly IConfigurationRoot config;

        public UserAuthenServiceTest()
        {
            appSetting = new AppSettingStub();
            config = new ConfigurationBuilder()
            .AddInMemoryCollection(appSetting.LoadAppSetting())
            .Build();
            service = new UserAuthenService(config, new DataServiceStub(), new TokenServiceStub(), new CustomerServiceStub());
        }

        [Fact]
        public void Case001_GetCustomerInformation_Success()
        {
            RequestUserAuthenModel model = new RequestUserAuthenModel
            {
                username = "tanapoom",
                password = "Aa112233",
            };

            var result = service.Login(model);

            Assert.Equal("1639800146777", result.data.idCardNumber);
        }

        [Fact]
        public void Case002_GetCustomerInformation_Error_Dup_ID()
        {
            RequestUserAuthenModel model = new RequestUserAuthenModel
            {
                username = "demo01",
                password = "Aa112233",
            };

            var result = service.Login(model);

            Assert.Equal(500, result.status);
        }

        [Fact]
        public void Case003_GetCustomerInformation_Error_Status_Lock()
        {
            RequestUserAuthenModel model = new RequestUserAuthenModel
            {
                username = "demo02",
                password = "Aa112233",
            };

            var result = service.Login(model);

            Assert.Equal(500, result.status);
        }

        [Fact]
        public void Case004_GetCustomerInformation_Error_NotFound()
        {
            RequestUserAuthenModel model = new RequestUserAuthenModel
            {
                username = "demo88",
                password = "Aa112233",
            };

            var result = service.Login(model);

            Assert.Equal(500, result.status);
        }

        [Fact]
        public void Case005_GetCustomerInformation_Error_Invalid_Password()
        {
            RequestUserAuthenModel model = new RequestUserAuthenModel
            {
                username = "tanapoom",
                password = "Aa112244",
            };

            var result = service.Login(model);

            Assert.Equal(500, result.status);
        }
    }
}
