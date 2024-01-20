using BusinessLogic.restful_booker.Authenticate;

namespace TestProject.Restfull.Booker.Auth
{
    public class ApiAuthFixture
    {
        public IAuth AuthService { get; }
        public ApiAuthFixture()
        {
            var client = new HttpClient();
            AuthService = new BusinessLogic.restful_booker.Authenticate.Auth(client);
        }
    }
}
