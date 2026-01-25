using System.ComponentModel.DataAnnotations;
using Server.Application.Auth;

namespace Server.Handlers.Auth.V1;

public static class VerifyEmail
{
  public static async Task<IResult> Handle(VerifyEmailRequest request, ICognitoService cognito)
  {
    await cognito.VerifyEmailAsync(request);

    return Results.Ok();
  }

}

public record VerifyEmailRequest(
  [Required, EmailAddress]
    string Email,
  [Required]
    string Code);
