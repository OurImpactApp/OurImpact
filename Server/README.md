# OurImpact Server

The .NET server backend for OurImpact.

## Setup

1. **Deploy AWS Infrastructure**: First, follow the deployment steps in [../deployment/README.md](../deployment/README.md) to set up the required AWS resources (Cognito User Pool).

2. **Get Cognito Client ID**: After deployment, retrieve the Cognito Client ID from the AWS Console or CDK outputs.

3. **Run the Server**: Start the development server with your Cognito Client ID:

```bash
COGNITO_CLIENT_ID=your-client-id dotnet run
```

Or for development with hot reload:

```bash
COGNITO_CLIENT_ID=your-client-id dotnet watch
```

## Requirements

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
