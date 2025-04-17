using APIHelperLIB.Services;
using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CustomerAPI.Services
{
    public class DataService : IDataService
    {
        private readonly CustomerInfoContext customerDb;

        public DataService(CustomerInfoContext customerDb) 
        {
            this.customerDb = customerDb;
        }

        public ResultCustomerInfoModel Get_CustomerInfomation_By_CustNumber(string customerNumber)
        {
            try
            {
                var ent = customerDb.custMasterInfoEntity;

                var result = (from tb in ent
                              where tb.customerNumber == customerNumber
                              select tb).FirstOrDefault();

                var data = JsonSerializer.Serialize(result).ToMyModel<ResultCustomerInfoModel>();
                return data;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Failed get customer infomation by CustomerNumber. " + ex.Message);
            }
        }
    }
}
