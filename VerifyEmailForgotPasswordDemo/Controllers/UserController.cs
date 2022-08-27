namespace VerifyEmailForgotPasswordDemo.Controllers
{
    using System.Security.Cryptography;

    public class UserController : ApiController
    {
        private readonly DataContext context;

        public UserController(DataContext context)
            => this.context = context;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (this.context.Users.Any(x => x.Email == request.Email))
            {
                return BadRequest("User with given email is already exist!");
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

            return Ok("User successfully created!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!this.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest("Not verified!");
            }

            return Ok($"Welcome back, {user.Email}");
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);

            if (user == null)
            {
                return BadRequest("Invalid Token");
            }

            user.VerifiedAt = DateTime.Now;
            await this.context.SaveChangesAsync();

            return Ok("User verified!");
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
