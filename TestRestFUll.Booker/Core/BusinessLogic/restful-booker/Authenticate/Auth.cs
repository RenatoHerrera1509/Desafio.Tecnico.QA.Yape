using Models.Auth;
using Newtonsoft.Json;
using System.Text;

namespace BusinessLogic.restful_booker.Authenticate
{
    public class Auth : IAuth
    {
        private readonly HttpClient _httpClient;
        private readonly string _authUrl;

        public Auth(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _authUrl = "https://restful-booker.herokuapp.com/auth";
        }

        public async Task<ApiResponse<AuthResponse>> AuthenticateAsync(AuthRequestDto request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response;

            response = await _httpClient.PostAsync(_authUrl, content);
            response.EnsureSuccessStatusCode();
            
            return await HttpResponseHelper.CreateApiResponseAsync<AuthResponse>(response);
        }
    }
}
