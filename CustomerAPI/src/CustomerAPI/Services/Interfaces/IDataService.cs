using CustomerAPI.Models;

namespace CustomerAPI.Services.Interfaces
{
    public interface IDataService
    {
        ResultCustomerInfoModel Get_CustomerInfomation_By_CustNumber(string customerNumber);
    }
}
