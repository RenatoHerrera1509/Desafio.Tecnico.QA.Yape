namespace Models.Auth
{
    public class AuthRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }

        public AuthRequestDto(string _username, string _password)
        {
            username = _username;
            password = _password;   
        }
    }
}
