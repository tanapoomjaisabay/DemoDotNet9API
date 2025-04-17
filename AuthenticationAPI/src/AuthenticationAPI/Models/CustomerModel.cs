using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIHelperLIB.Models;

namespace AuthenticationAPI.Models
{
    public class RequestGeneralInfoModel : RequestModel
    {
        public string customerNumber { get; set; } = string.Empty;
    }

    public class ResponseCustomerInfoModel : ResponseModel
    {
        public ResultCustomerInfoModel? data { get; set; }
    }

    public class ResultCustomerInfoModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string idCardNumber { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public DateTime birthDate { get; set; }
        public string gender { get; set; } = string.Empty;
        public string? mobileNumber { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
    }
}
