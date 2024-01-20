using Newtonsoft.Json;

namespace BusinessLogic
{
    public static class HttpResponseHelper
    {
        public static async Task<ApiResponse<T>> CreateApiResponseAsync<T>(HttpResponseMessage response)
        {
            var apiResponse = new ApiResponse<T>
            {
                StatusCode = (int)response.StatusCode,
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                ResponseMessage = response
            };

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                apiResponse.Result = JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                apiResponse.ErrorMessage = response.ReasonPhrase;
            }

            return apiResponse;
        }
    }

}
