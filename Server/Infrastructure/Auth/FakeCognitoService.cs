using Amazon.CognitoIdentityProvider.Model;
using Server.Application.Auth;
using Server.Handlers.Auth.V1;

public class FakeCognitoService : ICognitoService
{
  public Task<SignUpResponse> RegisterAsync(RegisterRequest request)
  {
    // simulate success
    return Task.FromResult(new SignUpResponse());
  }

  public Task VerifyEmailAsync(VerifyEmailRequest request)
  {
    return Task.CompletedTask;
  }
}
