using System.ComponentModel.DataAnnotations;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Server.Handlers.Auth.V1;

public static class VerifyEmail
{
  public static async Task<IResult> Handle(Request request, AmazonCognitoIdentityProviderClient client)
  {
    var cognitoClientId = Environment.GetEnvironmentVariable("COGNITO_CLIENT_ID");
    if (string.IsNullOrEmpty(cognitoClientId))
    {
      return Results.Problem("Cognito Client ID is not configured.");
    }

    var confirmSignUpRequest = new ConfirmSignUpRequest
    {
      ClientId = cognitoClientId,
      Username = request.Email,
      ConfirmationCode = request.Code
    };

    await client.ConfirmSignUpAsync(confirmSignUpRequest);

    return Results.Ok();
  }

  public record Request(
    [Required, EmailAddress]
    string Email,
    [Required]
    string Code);
}