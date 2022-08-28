namespace VerifyEmailForgotPasswordDemo.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using VerifyEmailForgotPasswordDemo.Data.Data;
    using VerifyEmailForgotPasswordDemo.Data.Data.Models;
    using VerifyEmailForgotPasswordDemo.Services.Interfaces;
    using VerifyEmailForgotPasswordDemo.Services.Models;

    public class UsersService : IUsersService
    {
        private readonly DataContext context;

        public UsersService(DataContext context)
            => this.context = context;

        public async Task<bool> IsExist(string email)
            => await this.context.Users.AnyAsync(x => x.Email == email);

        public async Task<Result> Login(UserLoginRequest request)
        {
            if (!await this.IsExist(request.Email))
            {
                return new Result(false, "User with given email is already exist!");
            }

            return new Result(true);
        }

        public async Task<Result> Register(UserRegisterRequest request)
        {
            if (await this.IsExist(request.Email))
            {
                return new Result(false, "User with given email is already exist!");
            }

            this.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            return new Result(true, "User successfully created!");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateRandomToken()
            => Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }
}
