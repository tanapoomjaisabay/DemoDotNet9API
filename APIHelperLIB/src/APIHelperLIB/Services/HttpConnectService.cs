using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using APIHelperLIB.Models;
using Microsoft.Extensions.Configuration;

namespace APIHelperLIB.Services
{
    public class HttpConnectService : IHttpConnectService
    {
        private readonly IConfiguration _configuration;

        public HttpConnectService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public string PostAPI(HttpParameterModel request)
        {
            string url = "";

            try
            {
                using var client = new HttpClient();

                url = request.host + request.controller;
                var content = new StringContent(request.jsonData, Encoding.UTF8, request.contentType);
                client.Timeout = TimeSpan.FromSeconds(request.timeout);

                foreach (var header in request.headers)
                {
                    client.DefaultRequestHeaders.Add(header.name.Trim(), header.value.Trim());
                }

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"StatusCode={(int)response.StatusCode}. StatusDesc: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to post HTTP request [{url}]. {ex.Message}");
            }
        }

        public async Task<string> PostAPIAsync(HttpParameterModel request)
        {
            string url = "";

            try
            {
                using var client = new HttpClient();

                url = request.host + request.controller;
                var content = new StringContent(request.jsonData, Encoding.UTF8, request.contentType);
                client.Timeout = TimeSpan.FromSeconds(request.timeout);

                foreach (var header in request.headers)
                {
                    client.DefaultRequestHeaders.Add(header.name.Trim(), header.value.Trim());
                }

                // await คือ รอคำสั่งนั้น(hold) และออกไปทำอย่างอื่นก่อน
                var response = await client.PostAsync(url, content);

                // จะทำหลังจากที่ .Result response
                // .Result จะรอ HttpResponse จนสำเร็จแล่วค่อยทำต่อ
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to post HTTP request [{url}]. {ex.Message}");
            }
        }

        public string GetAPI(HttpParameterModel request)
        {
            string url = "";

            try
            {
                using var client = new HttpClient();

                url = request.host + request.controller;
                client.Timeout = TimeSpan.FromSeconds(request.timeout);

                foreach (var header in request.headers)
                {
                    client.DefaultRequestHeaders.Add(header.name.Trim(), header.value.Trim());
                }

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"StatusCode={response.StatusCode}. Response Content: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to get HTTP request [{url}]. {ex.Message}");
            }
        }

        public async Task<string> GetAPIAsync(HttpParameterModel request)
        {
            string url = "";

            try
            {
                using var client = new HttpClient();

                url = request.host + request.controller;
                client.Timeout = TimeSpan.FromSeconds(request.timeout);

                foreach (var header in request.headers)
                {
                    client.DefaultRequestHeaders.Add(header.name.Trim(), header.value.Trim());
                }

                // await คือ รอคำสั่งนั้น(hold) และออกไปทำอย่างอื่นก่อน
                var response = await client.GetAsync(url);

                // จะทำหลังจากที่ .Result response
                // .Result จะรอ HttpResponse จนสำเร็จแล่วค่อยทำต่อ
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to get HTTP request [{url}]. {ex.Message}");
            }
        }
    }

    public interface IHttpConnectService
    {
        string PostAPI(HttpParameterModel request);
        Task<string> PostAPIAsync(HttpParameterModel request);
        string GetAPI(HttpParameterModel request);
        Task<string> GetAPIAsync(HttpParameterModel request);
    }
}
