global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

global using VerifyEmailForgotPasswordDemo.Data.Data;

global using VerifyEmailForgotPasswordDemo.Services;
global using VerifyEmailForgotPasswordDemo.Services.Models;
global using VerifyEmailForgotPasswordDemo.Services.Interfaces;

public static class EndPoints
{
    public const string RegisterEndPoint = "register";
    public const string LoginEndPoint = "login";
    public const string VerifyEndPoint = "verify";
    public const string ForgotPasswordEndPoint = "forgot-password";
    public const string ResetPasswordEndPoint = "reset-password";
}

public static class UsersMessages
{
    //Erorr messages
    public const string EmailAlreadyExist = "User with given email is already exist!";
    public const string UserNotFound = "User not found.";
    public const string IncorrectPassword = "Password is incorrect.";
    public const string NotVerified = "Not verified!";
    public const string InvalidToken = "Invalid Token";

    // Success messages
    public const string UserCreated = "User successfully created!";
    public const string ResetPasswordSuccessfully = "Paswword successfully reset.";
    public const string YouMayResetYourPassword = "You may now reset your password.";
    public const string UserVerified = "User verified!";
    public const string WelcomeBack = "Welcome back, {0}";

}