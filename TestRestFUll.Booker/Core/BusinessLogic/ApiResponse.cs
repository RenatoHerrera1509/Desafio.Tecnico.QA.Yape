namespace BusinessLogic
{
    public class ApiResponse<T>
    {
        public bool IsSuccessStatusCode { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }
    }
}
