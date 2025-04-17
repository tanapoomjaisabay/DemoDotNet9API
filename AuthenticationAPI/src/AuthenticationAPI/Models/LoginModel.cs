using System.ComponentModel.DataAnnotations;
using APIHelperLIB.Models;
using AuthenticationAPI.DataAccess;

namespace AuthenticationAPI.Models
{
    public class RequestUserAuthenModel : RequestModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your password")]
        public string password { get; set; } = string.Empty;
    }

    public class ResponseAuthenModel : ResponseModel
    {
        public ResultLoginUserPassModel? data { get; set; }
    }

    public class ResultLoginUserPassModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string customerStatus { get; set; } = string.Empty;
        public string idCardNumber { get; set; } = string.Empty;
        public string birthDate { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string mobileNumber { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }

    public class UserIdentityModel : CustAuthenEntity
    {
        public string token { get; set; } = string.Empty;
    }
}