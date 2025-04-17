using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.DataAccess;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Tests.StubServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuthenticationAPI.Tests.ServiceTests
{
    public class DataServiceTest
    {
        private readonly DataService service;
        private readonly CustomerAuthenContext _context;

        public DataServiceTest()
        {
            string id = Guid.NewGuid().ToString();
            var contextMemory = new DbContextOptionsBuilder<CustomerAuthenContext>().UseInMemoryDatabase(id)
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            _context = new CustomerAuthenContext(contextMemory.Options);
            _context.LoadDataCustomerInfo();

            service = new DataService(_context);
        }

        [Fact]
        public void Case001_GetCustomerInformation_Success()
        {
            string input = "tanapoom";

            List<UserIdentityModel> result = service.Get_AuthenData_By_Username(input);

            Assert.Equal("tanapoom", result.First().username);
        }

        [Fact]
        public void Case002_GetCustomerInformation_Error_Not_FoundData()
        {
            string input = "demo99";


            List<UserIdentityModel> result = service.Get_AuthenData_By_Username(input);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void Case003_GetCustomerInformation_Error_Context()
        {
            string input = "demo99";

            DataService service = new DataService(null);
            bool testResult = true;

            try
            {
                List<UserIdentityModel> result = service.Get_AuthenData_By_Username(input);
            }
            catch (Exception)
            {
                testResult = false;
            }

            Assert.False(testResult);
        }

        //[Fact]
        //public void Case002_GetCustomerInformation_Error_Not_FoundData()
        //{
        //    string input = "demo01";

        //    bool testResult = true;
        //    try
        //    {
        //        List<UserIdentityModel> result = service.Get_AuthenData_By_Username(input);
        //    }
        //    catch (Exception)
        //    {
        //        testResult = false;
        //    }

        //    Assert.False(testResult);
        //}
    }
}
