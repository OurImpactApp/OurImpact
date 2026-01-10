using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Server.Handlers.Auth.V1;

public static class Login
{
  public static async Task<IResult> Handle(Request request, AmazonCognitoIdentityProviderClient client)
  {
    var cognitoClientId = Environment.GetEnvironmentVariable("COGNITO_CLIENT_ID");
    if (string.IsNullOrEmpty(cognitoClientId))
    {
      return Results.Problem("Cognito Client ID is not configured.");
    }

    var authRequest = new InitiateAuthRequest
    {
      AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
      ClientId = cognitoClientId,
      AuthParameters = new Dictionary<string, string>
      {
        { "USERNAME", request.Email },
        { "PASSWORD", request.Password }
      }
    };
    var response = await client.InitiateAuthAsync(authRequest);

    return Results.Ok(new Response(
      AccessToken: response.AuthenticationResult.AccessToken,
      IdToken: response.AuthenticationResult.IdToken,
      RefreshToken: response.AuthenticationResult.RefreshToken
    ));
  }
}

public record Request(
  string Email,
  string Password);
public record Response(
  string AccessToken,
  string IdToken,
  string RefreshToken);
