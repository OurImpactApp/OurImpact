using System.ComponentModel.DataAnnotations;
using Server.Application.Auth;

namespace Server.Handlers.Auth.V1;

public static class Register
{
  public static async Task<IResult> Handle(RegisterRequest request, ICognitoService cognito)
  {
    var response = await cognito.RegisterAsync(request);

    return Results.Created($"/auth/v1/users/{response.UserSub}", new RegisterResponse(
      Id: response.UserSub,
      Email: request.Email,
      FullName: request.FullName
    ));
  }
}
public record RegisterRequest(
  [Required, EmailAddress]
    string Email,
  [Required, MinLength(8)]
    string Password,
  [Required]
    string FullName);

public record RegisterResponse(string Id, string Email, string FullName);
