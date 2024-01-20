using Models.Auth;

namespace BusinessLogic.restful_booker.Authenticate
{
    public interface IAuth
    {
        Task<ApiResponse<AuthResponse>> AuthenticateAsync(AuthRequestDto request);
    }
}
