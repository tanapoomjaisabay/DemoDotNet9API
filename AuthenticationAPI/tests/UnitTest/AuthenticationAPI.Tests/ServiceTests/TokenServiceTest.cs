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
    public class TokenServiceTest
    {
        private readonly TokenService service;
        private readonly AppSettingStub appSetting;
        private readonly IConfigurationRoot config;

        public TokenServiceTest()
        {
            appSetting = new AppSettingStub();
            config = new ConfigurationBuilder()
            .AddInMemoryCollection(appSetting.LoadAppSetting())
            .Build();
            service = new TokenService(config);
        }

        [Fact]
        public void Case001_BuildToken_Success()
        {
            UserIdentityModel model = new UserIdentityModel
            {
                customerNumber = "1000000001",
                username = "tanapoom"
            };

            var property = service.GetTokenProperty(model, "UNITTEST");
            var token = service.BuildToken(property);

            Assert.True(token != null);
        }
    }
}
