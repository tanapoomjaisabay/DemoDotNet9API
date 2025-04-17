using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Services.Interfaces;

namespace AuthenticationAPI.Tests.StubServices
{
    public class CustomerServiceStub : ICustomerService
    {
        public ResultLoginUserPassModel GetCustomerInformation(UserIdentityModel userIdentity, string deviceInfo)
        {
            return new ResultLoginUserPassModel 
            {
                customerNumber = "1000000001",
                name = "Tanapoom Jaisabay",
                idCardNumber = "1639800146777",
                mobileNumber = "0801192770",
                birthDate = "15/11/2536",
                customerStatus = "A",
                gender = "M"
            };
        }
    }
}
