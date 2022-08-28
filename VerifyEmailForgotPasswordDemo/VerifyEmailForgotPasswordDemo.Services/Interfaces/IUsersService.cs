namespace VerifyEmailForgotPasswordDemo.Services.Interfaces
{
    using VerifyEmailForgotPasswordDemo.Services.Models;

    public interface IUsersService
    {
        Task<Result> Register(UserRegisterRequest request);

        Task<Result> Login(UserLoginRequest request);

        Task<bool> IsExist(string email);
    }
}
