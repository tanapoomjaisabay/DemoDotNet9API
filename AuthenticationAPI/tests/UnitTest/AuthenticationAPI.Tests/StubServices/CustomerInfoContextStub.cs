using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.DataAccess;

namespace AuthenticationAPI.Tests.StubServices
{
    public static class CustomerInfoContextStub
    {
        public static void LoadDataCustomerInfo(this CustomerAuthenContext context)
        {
            context.authenEntity.AddRange
                (new CustAuthenEntity
                {
                    idKey = 1,
                    customerNumber = "1000000001",
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    username = "tanapoom",
                    changePassword = 0,
                    invalidPassword = 0,
                    status = "A",
                    updateBy = "UNITTEST",
                    updateDatetime = DateTime.Now,
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                }, new CustAuthenEntity
                {
                    idKey = 2,
                    customerNumber = "1000000901",
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    username = "demo01",
                    changePassword = 0,
                    invalidPassword = 0,
                    status = "A",
                    updateBy = "UNITTEST",
                    updateDatetime = DateTime.Now,
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                }, new CustAuthenEntity
                {
                    idKey = 3,
                    customerNumber = "1000000902",
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    username = "demo01",
                    changePassword = 0,
                    invalidPassword = 0,
                    status = "A",
                    updateBy = "UNITTEST",
                    updateDatetime = DateTime.Now,
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                }, new CustAuthenEntity
                {
                    idKey = 4,
                    customerNumber = "1000000903",
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    username = "demo03",
                    changePassword = 0,
                    invalidPassword = 3,
                    status = "L",
                    updateBy = "UNITTEST",
                    updateDatetime = DateTime.Now,
                    createBy = "UNITTEST",
                    createDatetime = DateTime.Now
                });

            context.SaveChanges();
        }
    }
}
