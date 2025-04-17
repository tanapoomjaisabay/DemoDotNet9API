using APIHelperLIB.Services;
using AuthenticationAPI.DataAccess;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace AuthenticationAPI.Services
{
    public class DataService : IDataService
    {
        private readonly CustomerAuthenContext _context;

        public DataService(CustomerAuthenContext context)
        {
            _context = context;
        }

        public List<UserIdentityModel> Get_AuthenData_By_Username(string username)
        {
            try
            {
                var ent = _context.authenEntity;

                var result = (from d in ent
                              where d.username == username
                              select d).ToList();

                var data = JsonSerializer.Serialize(result).ToMyModel<List<UserIdentityModel>>();
                return data;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Failed get authentication data by Username. " + ex.ToMessage());
            }
        }
    }
}
