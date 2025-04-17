using CustomerAPI.Models;

namespace CustomerAPI.Services.Interfaces
{
    public interface IGeneralInfoService
    {
        ResponseCustomerInfoModel GetCustomerInformation(RequestGeneralInfoModel model);
    }
}
