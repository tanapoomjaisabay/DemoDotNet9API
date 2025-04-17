using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services;
using CustomerAPI.Tests.StubServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CustomerAPI.Tests.ServiceTests
{
    public class DataServiceTest
    {
        private readonly DataService service;
        private readonly CustomerInfoContext _context;

        public DataServiceTest()
        {
            string id = Guid.NewGuid().ToString();
            var contextMemory = new DbContextOptionsBuilder<CustomerInfoContext>().UseInMemoryDatabase(id)
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            _context = new CustomerInfoContext(contextMemory.Options);
            _context.LoadDataCustomerInfo();

            service = new DataService(_context);
        }

        [Fact]
        public void Case001_GetCustomerInformation_Success()
        {
            string input = "1000000001";

            ResultCustomerInfoModel result = service.Get_CustomerInfomation_By_CustNumber(input);

            Assert.Equal("1639800146777", result.idCardNumber);
        }

        [Fact]
        public void Case002_GetCustomerInformation_Error_Not_FoundData()
        {
            string input = "1000000009";

            bool testResult = true;
            try
            {
                ResultCustomerInfoModel result = service.Get_CustomerInfomation_By_CustNumber(input);
            }
            catch (Exception)
            {
                testResult = false;
            }

            Assert.False(testResult);
        }
    }
}
