namespace VerifyEmailForgotPasswordDemo.Controllers
{
    using System.Security.Cryptography;
    using static UsersMessages;
    using static EndPoints;

    public class UserController : ApiController
    {
        private readonly DataContext context;

        public UserController(DataContext context)
            => this.context = context;

        [HttpPost(RegisterEndPoint)]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (this.context.Users.Any(x => x.Email == request.Email))
            {
                return BadRequest(EmailAlreadyExist);
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

            return Ok(UserCreated);
        }

        [HttpPost(LoginEndPoint)]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                return BadRequest(UserNotFound);
            }

            if (!this.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest(IncorrectPassword);
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest(NotVerified);
            }

            return Ok(string.Format(WelcomeBack, user.Email));
        }

        [HttpPost(VerifyEndPoint)]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);

            if (user == null)
            {
                return BadRequest(InvalidToken);
            }

            user.VerifiedAt = DateTime.Now;
            await this.context.SaveChangesAsync();

            return Ok(UserVerified);
        }

        [HttpPost(ForgotPasswordEndPoint)]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return BadRequest(UserNotFound);
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await this.context.SaveChangesAsync();

            return Ok(YouMayResetYourPassword);
        }

        [HttpPost(ResetPasswordEndPoint)]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.PasswordResetToken == request.Token);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest(InvalidToken);
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await this.context.SaveChangesAsync();

            return Ok(ResetPasswordSuccessfully);
        }

        private string CreateRandomToken()
            => Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
