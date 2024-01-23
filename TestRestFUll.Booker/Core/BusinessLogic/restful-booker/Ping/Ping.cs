using Models.GetBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.restful_booker.Ping
{
    public class Ping : IPing
    {
        private readonly HttpClient _httpClient;
        private readonly string _pingUrl;

        public Ping(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _pingUrl = "https://restful-booker.herokuapp.com/ping";
        }
        public async Task<bool> HealthCheckAsync()
        {
            var response = await _httpClient.GetAsync(_pingUrl);
            return response.IsSuccessStatusCode;
        }
    }
}
