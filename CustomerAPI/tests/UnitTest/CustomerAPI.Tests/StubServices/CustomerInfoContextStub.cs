using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.DataAccess;

namespace CustomerAPI.Tests.StubServices
{
    public static class CustomerInfoContextStub
    {
        public static void LoadDataCustomerInfo(this CustomerInfoContext context)
        {
            context.custMasterInfoEntity.AddRange
                (new CustomerMasterInfoEntity
                {
                    idKey = 1,
                    customerNumber = "1000000001",
                    idCardNumber = "1639800146777",
                    nameTH = "ธนภูมิ",
                    surnameTH = "ใจสบาย",
                    nameEN = "Tanapoom",
                    surnameEN = "Jaisabay",
                    birthDate = DateTime.Now,
                    gender = "M",
                    status = "A",
                    mobileNumber = "0801192777",
                    email = "test@gmail.com111",
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                }, new CustomerMasterInfoEntity 
                {
                    idKey = 2,
                    customerNumber = "1000000002",
                    idCardNumber = "1639800146777",
                    nameTH = "ทดสอบ",
                    surnameTH = "เอพี่ไอ",
                    nameEN = "Test",
                    surnameEN = "API",
                    birthDate = DateTime.Now,
                    gender = "F",
                    status = "A",
                    mobileNumber = "0801192000",
                    email = "test02@gmail.com111",
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                });

            context.SaveChanges();
        }
    }
}
