using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperLIB.Models
{
    public class HttpParameterModel
    {
        public string host { get; set; } = string.Empty;
        public string controller { get; set; } = string.Empty;
        public string jsonData { get; set; } = string.Empty;
        public string contentType { get; set; } = "application/json";
        public List<HttpHeaderModel> headers { get; set; } = new List<HttpHeaderModel>();
        public int timeout { get; set; } = 30; //sec
    }

    public class HttpHeaderModel
    {
        public string name { get; set; } = string.Empty;
        public string value { get; set; } = string.Empty;
    }
}
