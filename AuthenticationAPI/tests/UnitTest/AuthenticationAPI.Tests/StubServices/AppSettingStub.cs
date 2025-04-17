using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.Tests.StubServices
{
    public class AppSettingStub
    {
        public Dictionary<string, string> LoadAppSetting()
        {
            Dictionary<string, string> appSettings = new Dictionary<string, string>();
            appSettings.Add("JWT:SecretKey", "m716rGPKT6UR7MI9n7jhbpCIBpXQIBMi");
            appSettings.Add("JWT:Issuer", "authentication-api");
            appSettings.Add("JWT:ExpireMinutes", "180");
            appSettings.Add("ConnectionStrings:DemoContext", "Data Source=sqlserver;");
            appSettings.Add("CustomerService:URL", "http://customerapi:8080/api/");

            return appSettings;
        }
    }
}
