using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;

namespace AuthenticationAPI.Tests.StubServices
{
    class TokenServiceStub : ITokenService
    {
        public string BuildToken(BuildTokenModel model)
        {
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ByaW1hcnlzaWQiOiIxMDAwMDAwMDAxIiwianRpIjoiMzhlYTQxOWMtNTQzNC00MzU2LWJlODgtNzIxZTJmYWIzNjNiIiwiZXhwIjoxNzQ0ODA2MzA1LCJpc3MiOiJhdXRoZW50aWNhdGlvbi1hcGkifQ.U6Qzk_kcoXz41l5l2EMwHKKa2JJKsp2_iOLMV8V3z4Y";
        }

        public BuildTokenModel GetTokenProperty(UserIdentityModel custInfo, string deviceInfo)
        {
            return new BuildTokenModel
            {
                customerNumber = custInfo.customerNumber,
                deviceInfo = deviceInfo,
                expireMinutes = 60,
                issuer = "issuer",
                secretKey = "secretKey"
            };
        }
    }
}
