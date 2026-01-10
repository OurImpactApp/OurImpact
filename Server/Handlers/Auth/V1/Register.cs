using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Server.Handlers.Auth.V1;

public static class Register
{
  public static async Task<IResult> Handle(Request request, AmazonCognitoIdentityProviderClient client)
  {
    var cognitoClientId = Environment.GetEnvironmentVariable("COGNITO_CLIENT_ID");
    if (string.IsNullOrEmpty(cognitoClientId))
    {
      Debug.WriteLine("Cognito Client ID is not configured.");
      return Results.Problem();
    }

    var attributes = new List<AttributeType>
    {
      new() {
        Name = "email",
        Value = request.Email
      },
      new() {
        Name = "name",
        Value = request.FullName
      }
    };

    var signUpRequest = new SignUpRequest
    {
      ClientId = cognitoClientId,
      Username = request.Email,
      Password = request.Password,
      UserAttributes = attributes
    };

    var response = await client.SignUpAsync(signUpRequest);

    return Results.Created($"/auth/v1/users/{response.UserSub}", new Response(
      Id: response.UserSub,
      Email: request.Email,
      FullName: request.FullName
    ));
  }
  public record Request(
    [Required, EmailAddress]
    string Email,
    [Required, MinLength(8)]
    string Password,
    [Required]
    string FullName);
  public record Response(string Id, string Email, string FullName);
}
