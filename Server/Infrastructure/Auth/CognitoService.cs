using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Server.Handlers.Auth.V1;
namespace Server.Application.Auth;

public class CognitoService : ICognitoService
{
  private readonly IAmazonCognitoIdentityProvider _cognito;
  private readonly string cognitoClientId;

  public CognitoService(IAmazonCognitoIdentityProvider cognito)
  {
    _cognito = cognito;
    cognitoClientId = Environment.GetEnvironmentVariable("COGNITO_CLIENT_ID") ?? throw new InvalidOperationException("Cognito Client ID is not configured.");
  }

  public async Task<SignUpResponse> RegisterAsync(RegisterRequest request)
  {
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

    var response = await _cognito.SignUpAsync(signUpRequest);

    return response;
  }

  public async Task VerifyEmailAsync(VerifyEmailRequest request)
  {
    var confirmSignUpRequest = new ConfirmSignUpRequest
    {
      ClientId = cognitoClientId,
      Username = request.Email,
      ConfirmationCode = request.Code
    };

    await _cognito.ConfirmSignUpAsync(confirmSignUpRequest);
  }
}
