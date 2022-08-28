namespace VerifyEmailForgotPasswordDemo.Services.Models
{
    public class Result
    {
        public Result(bool status, string errorMessage = "")
        {
            this.Status = status;
            this.ErrorMessage = errorMessage;
        }

        public bool Status { get; set; }

        public string ErrorMessage { get; set; }
    }
}
