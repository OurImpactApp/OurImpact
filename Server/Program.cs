
using Server.Handlers.Auth.V1;
using Amazon.CognitoIdentityProvider;
var builder = WebApplication.CreateBuilder(args);

// Add Swashbuckle services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddValidation();

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var client = new AmazonCognitoIdentityProviderClient();

app.MapPost("/auth/v1/register", (Register.Request request) => Register.Handle(request, client))
   .WithName("Register")
   .Accepts<Register.Request>("application/json")
   .Produces(StatusCodes.Status201Created)
   .ProducesValidationProblem()
   .WithSummary("Register a new user")
   .WithDescription("Creates a new user account in the system");

app.MapPost("/auth/v1/verify-email", (VerifyEmail.Request request) => VerifyEmail.Handle(request, client))
   .WithName("VerifyEmail")
   .Accepts<VerifyEmail.Request>("application/json")
   .Produces(StatusCodes.Status200OK)
   .ProducesValidationProblem()
   .WithSummary("Verify email address")
   .WithDescription("Verifies a user's email address using a confirmation code sent to their email.");

app.Run("http://localhost:8000");

