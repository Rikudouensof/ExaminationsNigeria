using ExaminationsNigeria.Application.Services;
using ExaminationsNigeria.Domain.Models;
using ExaminationsNigeria.Domain.Models.Database;
using ExaminationsNigeria.Domain.ViewModels.AuthViewModels;
using ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos;
using ExaminationsNigeria.Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Text;



namespace ExaminationsNigeria.Infrastructure.Services.TaskServices
{
  public class IndividualAuthService
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailService _emailService;
    private readonly IUserStore<User> _userStore;
    private readonly IUserEmailStore<User> _emailStore;


    public IndividualAuthService(UserManager<User> userManager,
      SignInManager<User> signInManager,
      IEmailService _emailService,
      IUserStore<User> userStore

      )
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _userStore = userStore;
      _emailStore = GetEmailStore();
    }


    public async Task<string> ConfirmEmail(string userId, string code)
    {
      if (userId == null || code == null)
      {
        return "User or code is empty";
      }

      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        return $"Unable to load user with ID '{userId}'.";
      }

      code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
      var result = await _userManager.ConfirmEmailAsync(user, code);
      var message = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
      return message;
    }

    public async Task<string> ConfirmEmailChange(string userId, string email, string code)
    {
      if (userId == null || email == null || code == null)
      {
        return "userId or email or code is empty";
      }

      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        return $"Unable to load user with ID '{userId}'.";
      }

      code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
      var result = await _userManager.ChangeEmailAsync(user, email, code);
      string statusMessage;
      if (!result.Succeeded)
      {
        statusMessage = "Error changing email.";
        return statusMessage;
      }

      // In our UI email and user name are one and the same, so when we update the email
      // we need to update the user name.
      var setUserNameResult = await _userManager.SetUserNameAsync(user, email);
      if (!setUserNameResult.Succeeded)
      {
        statusMessage = "Error changing user name.";
        return statusMessage;
      }

      await _signInManager.RefreshSignInAsync(user);
      statusMessage = "Thank you for confirming your email change.";
      return statusMessage;
    }

    public async Task<string> ForgotPassword(ForgotPasswordViewModel input)
    {
      try
      {
        var user = await _userManager.FindByEmailAsync(input.Email);
        if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
        {
          // Don't reveal that the user does not exist or is not confirmed
          return "We do not recognise this email address";
        }

        // For more information on how to enable account confirmation and password reset please
        // visit https://go.microsoft.com/fwlink/?LinkID=532713
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        var mailPayload = new EmailRequestDto()
        {
          DesinationEmail = input.Email,
          AppSettings = input.Appsettings,
          Body = $"Please reset your password by using this code {code}",
          EmailSourceName = input.Appsettings.SmtpEmailAddress,
          Subject = "Reset Password"
        };
        await _emailService.SendMailAsync(mailPayload);

        return "Please check your maail to confirm your email address";
      }
      catch
      {
        return "Failed";
      }

    }

    public async Task<string> ResetPassword(ResetPasswordViewModel input)
    {

      input.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(input.Code));
      var user = await _userManager.FindByEmailAsync(input.Email);
      if (user == null)
      {
        // Don't reveal that the user does not exist
        return "User not recognised";
      }

      var result = await _userManager.ResetPasswordAsync(user, input.Code, input.Password);
      if (result.Succeeded)
      {
        return "Success";
      }
      string errors = "";
      foreach (var error in result.Errors)
      {
        errors += $"\n {error}";
      }
      return errors;
    }

    public async Task<string> Register(RegisterViewModel input)
    {

      try
      {
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, input.UserName, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, input.Password);

        if (result.Succeeded)
        {
          //_logger.LogInformation("User created a new account with password.");

          var userId = await _userManager.GetUserIdAsync(user);
          var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

          var mailPayload = new EmailRequestDto()
          {
            DesinationEmail = input.Email,
            AppSettings = input.AppSettings,
            Body = $"Please verify your email by using this code {code}",
            EmailSourceName = input.AppSettings.SmtpEmailAddress,
            Subject = "Confirm your email"
          };
          await _emailService.SendMailAsync(mailPayload);

          return "Account created, Please confirm your email address";
        }

        var errors = "Create account errors \n";
        foreach (var error in result.Errors)
        {
          errors = errors + $"\n {error}";
        }
        return errors;
      }
      catch
      {
        return "Failed";
      }
      
    }

    public async Task<string> Login(LoginViewModel Input)
    {


      try
      {
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          //_logger.LogInformation("User logged in.");
          return "Sucess";
        }
        if (result.RequiresTwoFactor)
        {
          return "Requires Two Factor Autentication";
        }
        if (result.IsLockedOut)
        {
          //_logger.LogWarning("User account locked out.");
          return "Account is locked out";
        }
        else
        {
          
          return "Invalid login Attempt";
        }
      }
      catch
      {
        // If we got this far, something failed, redisplay form
        return "failed";
      }
     
    }

    #region Tasks
    private User CreateUser()
    {
      try
      {
        return Activator.CreateInstance<User>();
      }
      catch
      {
        throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
            $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
      }
    }

    private IUserEmailStore<User> GetEmailStore()
    {
      if (!_userManager.SupportsUserEmail)
      {
        throw new NotSupportedException("The default UI requires a user store with email support.");
      }
      return (IUserEmailStore<User>)_userStore;
    }

    #endregion


    
  }
}
