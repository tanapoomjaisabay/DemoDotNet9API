using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;

namespace CustomerAPI.Tests.StubServices
{
    public class DataServiceStub : IDataService
    {
        public ResultCustomerInfoModel Get_CustomerInfomation_By_CustNumber(string customerNumber)
        {
            ResultCustomerInfoModel result = new ResultCustomerInfoModel();

            if (customerNumber == "1000000001")
            {
                result.customerNumber = "1000000001";
                result.fullName = "Tanapoom Jaisabay";
                result.idCardNumber = "1639800146779";
                result.nameTH = "ธนภูมิ";
                result.surnameTH = "ใจสบาย";
                result.nameEN = "Tanapoom";
                result.surnameEN = "Jaisabay";
                result.birthDate = DateTime.Now;
                result.gender = "M";
                result.status = "A";
                result.mobileNumber = "0801192777";
                result.email = "test@gmail.com111";
            }
            else if (customerNumber == "9000000001")
            {
                throw new Exception("Can't connect database.");
            }
            else
            {
                throw new Exception("Not pass criteria.");
            }

            return result;
        }
    }
}
