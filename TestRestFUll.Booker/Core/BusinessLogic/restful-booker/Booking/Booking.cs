using BusinessLogic.restful_booker.Authenticate;
using Models.Auth;
using Models.Booking;
using Models.CreateBooking;
using Models.GetBooking;
using Models.PartialUpdate;
using Models.UpdateBooking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.restful_booker.Booking
{
    public class Booking : IBooking
    {
        private readonly HttpClient _httpClient;
        private readonly string _bookingUrl;
        private readonly IAuth _auth;
        private string _token;
        public Booking(HttpClient httpClient, IAuth auth)
        {
            _httpClient = httpClient;
            _auth = auth;
            _bookingUrl = "https://restful-booker.herokuapp.com/booking";
        }

        private async Task<string?> GetToken()
        {
            var requestDto = new AuthRequestDto("admin", "password123");
            var response = await _auth.AuthenticateAsync(requestDto);
            return response.Result.token;
        }

        public async Task<ApiResponse<CreateBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_bookingUrl, content);
            return await HttpResponseHelper.CreateApiResponseAsync<CreateBookingResponseDto>(response);
        }

        public async Task<ApiResponse<BookingDetailsResponseDto>> GetBookingAsync(int bookingId)
        {
            var response = await _httpClient.GetAsync($"{_bookingUrl}/{bookingId}");
            return await HttpResponseHelper.CreateApiResponseAsync<BookingDetailsResponseDto>(response);
        }

        public async Task<ApiResponse<IEnumerable<BookingResponseDto>>> GetBookingIdsAsync(BookingRequestDto request)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(request.firstName))
                query["firstname"] = request.firstName;

            if (!string.IsNullOrEmpty(request.lastName))
                query["lastname"] = request.lastName;

            if (!string.IsNullOrEmpty(request.checkIn))
                query["checkin"] = request.checkIn;

            if (!string.IsNullOrEmpty(request.checkOut))
                query["checkout"] = request.checkOut;

            string urlWithQuery = $"{_bookingUrl}?{query}";
            var response = await _httpClient.GetAsync(urlWithQuery);
            return await HttpResponseHelper.CreateApiResponseAsync<IEnumerable<BookingResponseDto>>(response);
        }

        public async Task<ApiResponse<BookingDetailsResponseDto>> UpdateBookingAsync(UpdateBookingRequestDto request)
        {
            _token = await GetToken();
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"token={_token}");
            var jsonRequest = JsonConvert.SerializeObject(request.dto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_bookingUrl}/{request.id}", content);
            return await HttpResponseHelper.CreateApiResponseAsync<BookingDetailsResponseDto>(response);
        }

        public async Task<ApiResponse<BookingDetailsResponseDto>> PartialUpdateBookingAsync(PartialUpdateBookingRequestDto request)
        {
            _token = await GetToken();
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"token={_token}");
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var jsonRequest = JsonConvert.SerializeObject(request.dt, settings);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"{_bookingUrl}/{request.id}", content);
            return await HttpResponseHelper.CreateApiResponseAsync<BookingDetailsResponseDto>(response);
        }

        public async Task<HttpResponseMessage> DeleteBookingAsync(int bookingId)
        {
            _token = await GetToken();
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"token={_token}");
            var response = await _httpClient.DeleteAsync($"{_bookingUrl}/{bookingId}");
            return response;
        }
    }
}
