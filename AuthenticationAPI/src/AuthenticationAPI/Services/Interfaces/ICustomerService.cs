using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        ResultLoginUserPassModel GetCustomerInformation(UserIdentityModel userIdentity, string deviceInfo);
    }
}
