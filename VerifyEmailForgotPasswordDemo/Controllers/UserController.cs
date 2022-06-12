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
    }
}
