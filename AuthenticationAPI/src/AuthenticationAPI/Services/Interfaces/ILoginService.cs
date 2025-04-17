using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface ILoginService
    {
        public ResponseAuthenModel Login(RequestUserAuthenModel model);
    }
}
