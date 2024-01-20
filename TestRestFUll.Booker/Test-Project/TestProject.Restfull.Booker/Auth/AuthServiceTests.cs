using BusinessLogic.restful_booker.Authenticate;
using Models.Auth;

namespace TestProject.Restfull.Booker.Auth
{
    public class AuthServiceTests : IClassFixture<ApiAuthFixture>
    {
        private readonly IAuth _authService;

        public AuthServiceTests(ApiAuthFixture fixture)
        {
            _authService = fixture.AuthService;
        }

        [Fact(DisplayName = "Autenticar token de devolución, cuando las credenciales sean válidas")]
        public async Task AuthenticateAsync_ReturnsToken_WhenCredentialsAreValid()
        {
            // Arrange
            var requestDto = new AuthRequestDto("admin", "password123");

            // Act
            var apiResponse = await _authService.AuthenticateAsync(requestDto);

            // Assert
            Assert.True(apiResponse.IsSuccessStatusCode); 
            Assert.NotNull(apiResponse.Result); 
            Assert.NotNull(apiResponse.Result.token); 
            Assert.NotEmpty(apiResponse.Result.token); 
            Assert.Equal(200, apiResponse.StatusCode);
            Assert.Null(apiResponse.ErrorMessage);
        }

        [Fact(DisplayName = "Autenticar devuelve token null, cuando las credenciales no son válidas")]
        public async Task AuthenticateAsync_ReturnsError_WhenCredentialsAreInvalid()
        {
            // Arrange
            var requestDto = new AuthRequestDto("incorrectUser", "incorrectPassword");

            // Act
            var apiResponse = await _authService.AuthenticateAsync(requestDto);

            // Assert
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.NotNull(apiResponse.Result);
            Assert.Null(apiResponse.Result.token);
            Assert.Equal(200, apiResponse.StatusCode);
            Assert.Null(apiResponse.ErrorMessage);
        }

    }
}
