using Server.Handlers.Auth.V1;
using Amazon.CognitoIdentityProvider;
using Server.Application.Auth;

Console.WriteLine($"Starting Server in {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} environment");

var builder = WebApplication.CreateBuilder(args);

// Add Swashbuckle services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddValidation();

builder.Services.AddAWSService<IAmazonCognitoIdentityProvider>();

builder.Services.AddScoped<ICognitoService>(sp =>
{
   if (builder.Environment.IsDevelopment())
   {
      Console.WriteLine("Using FakeCognitoService");
      return new FakeCognitoService();
   }

   return new CognitoService(
       sp.GetRequiredService<IAmazonCognitoIdentityProvider>());
});

var app = builder.Build();


// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/auth/v1/register", Register.Handle)
   .WithName("Register")
   .Accepts<RegisterRequest>("application/json")
   .Produces(StatusCodes.Status201Created)
   .ProducesValidationProblem()
   .WithSummary("Register a new user")
   .WithDescription("Creates a new user account in the system");

app.MapPost("/auth/v1/verify-email", VerifyEmail.Handle)
   .WithName("VerifyEmail")
   .Accepts<VerifyEmailRequest>("application/json")
   .Produces(StatusCodes.Status200OK)
   .ProducesValidationProblem()
   .WithSummary("Verify email address")
   .WithDescription("Verifies a user's email address using a confirmation code sent to their email.");

app.Run();

