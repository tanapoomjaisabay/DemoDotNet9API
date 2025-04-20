using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using APIHelperLIB.Services;
//using static APIHelperLIB.Services.;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Azure;

namespace AuthenticationAPI.Services
{
    public class UserAuthenService : ILoginService
    {
        private readonly ILogger<UserAuthenService> logger;
        private readonly IConfiguration config;
        private readonly IDataService dataService;
        private readonly ITokenService tokenService;
        private readonly ICustomerService custService;

        public UserAuthenService(ILogger<UserAuthenService> logger, IConfiguration config, IDataService dataService, ITokenService tokenService, ICustomerService custService)
        {
            this.logger = logger;
            this.config = config;
            this.dataService = dataService;
            this.tokenService = tokenService;
            this.custService = custService;
        }

        public ResponseAuthenModel Login(RequestUserAuthenModel model)
        {
            string errorMessage = "Login failed. Please enter a valid login name and password.";
            string logId = Guid.NewGuid().ToString();

            try
            {
                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.username, "UserAuthen", "IN", model, ""));
                
                // verify username and password
                UserIdentityModel userIdentity = VerifyUserName(model);
                VerifyPassword(userIdentity, model.password);

                // get user jwt token and customer infomation
                var tokenProp = tokenService.GetTokenProperty(userIdentity, model.deviceInfo);
                userIdentity.token = tokenService.BuildToken(tokenProp);

                var data = custService.GetCustomerInformation(userIdentity, model.deviceInfo);

                var response = new ResponseAuthenModel
                {
                    status = 200,
                    success = true,
                    data = data
                };

                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.username, "UserAuthen", "OUT", response, ""));
                return response;
            }
            catch (Exception ex)
            {
                var response = new ResponseAuthenModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.ToMessage()
                };

                logger.LogInformation(LogService.GetLogInfo(), LogService.GetLogDetail(logId, model.deviceInfo, model.username, "UserAuthen", "OUT", response, ex.ToMessage()));
                return response;
            }
        }

        private UserIdentityModel VerifyUserName(RequestUserAuthenModel model)
        {
            try
            {
                var authenData = dataService.Get_AuthenData_By_Username(model.username);

                if (authenData.Count == 0)
                {
                    throw new ValidationException("Username is not found");
                }
                else if (authenData.Count > 1)
                {
                    throw new ValidationException("Username has more than 1 row");
                }

                var userIdentity = authenData[0];
                if (userIdentity.status != "A")
                {
                    throw new ValidationException("Username is not active [" + userIdentity.status + "]");
                }
                else
                {
                    return userIdentity;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify username. " + ex.Message);
            }
        }

        private void VerifyPassword(UserIdentityModel userIdentity, string passwordInput)
        {
            try
            {
                string passwordEncrypt = SecurityService.EncryptPassword(passwordInput.Trim());
                if (userIdentity.password.Trim() != passwordEncrypt)
                {
                    throw new ValidationException("Password incorrect");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify password. " + ex.Message);
            }
        }
    }
}
