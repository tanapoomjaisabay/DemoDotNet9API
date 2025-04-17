using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(BuildTokenModel model);
        BuildTokenModel GetTokenProperty(UserIdentityModel custInfo, string deviceInfo);
    }
}
