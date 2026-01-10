# OurImpact Deployment

This directory contains the AWS CDK infrastructure for deploying OurImpact to AWS.

## Prerequisites

- [Node.js](https://nodejs.org/) (version 18 or later)
- [Bun](https://bun.sh/) package manager
- [AWS CLI](https://aws.amazon.com/cli/) version 2

## Deployment Steps

### Step 1: Configure AWS Credentials

Configure your AWS credentials by following the [AWS CLI Configuration Guide](https://docs.aws.amazon.com/cli/v1/userguide/cli-configure-files.html).

### Step 2: Install Dependencies

Navigate to the deployment directory and install dependencies:

```bash
cd deployment
bun install
```

### Step 3: Bootstrap CDK (First Time Only)

If this is your first time using CDK in this AWS account/region:

```bash
bun cdk bootstrap
```

### Step 4: Deploy to AWS

Deploy the staging environment:

```bash
DEPLOYMENT_SUFFIX=staging bun run deploy
```

## What Gets Deployed

This CDK stack creates:

- **Cognito User Pool**: For user authentication
- **Cognito User Pool Client**: For the mobile app to connect to the user pool

## Environment Variables

- `DEPLOYMENT_SUFFIX`: Must be set to `staging` (production deployment is not yet configured)

## Troubleshooting

### Permission Issues

Ensure your AWS credentials have the following permissions:

- CloudFormation (full access)
- Cognito (create/modify user pools)
- IAM (create roles and policies)

### Region Issues

Make sure your AWS CLI is configured for the correct region where you want to deploy.
