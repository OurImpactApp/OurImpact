using Amazon.CognitoIdentityProvider.Model;
using Server.Handlers.Auth.V1;

namespace Server.Application.Auth;

public interface ICognitoService
{
  Task<SignUpResponse> RegisterAsync(RegisterRequest request);
  Task VerifyEmailAsync(VerifyEmailRequest request);
}
