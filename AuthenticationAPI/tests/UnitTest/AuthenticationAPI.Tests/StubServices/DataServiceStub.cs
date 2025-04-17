using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;

namespace AuthenticationAPI.Tests.StubServices
{
    public class DataServiceStub : IDataService
    {
        public List<UserIdentityModel> Get_AuthenData_By_Username(string username)
        {
            List<UserIdentityModel> result = new List<UserIdentityModel>();

            if (username == "tanapoom")
            {
                result.Add(new UserIdentityModel 
                {
                    customerNumber = "1000000001",
                    username = username,
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    status = "A"
                });
            }
            else if (username == "demo01")
            {
                result.AddRange(new UserIdentityModel
                {
                    customerNumber = "1000000002",
                    username = username,
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    status = "A"
                }, new UserIdentityModel
                {
                    customerNumber = "1000000003",
                    username = username,
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    status = "A"
                });
            }
            else if (username == "demo02")
            {
                result.Add(new UserIdentityModel
                {
                    customerNumber = "1000000004",
                    username = username,
                    password = "Lwamx9PdY9khnFMiXjekcg==",
                    status = "L"
                });
            }
            else
            {
                return result;
                //throw new Exception("Not pass criteria.");
            }

            return result;
        }
    }
}
