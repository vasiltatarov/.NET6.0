namespace VerifyEmailForgotPasswordDemo.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters length!")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password must be the same as password!")]
        public string ConfirmPassword { get; set; }
    }
}
