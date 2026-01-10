import * as cdk from "aws-cdk-lib";
import { Construct } from "constructs";

export class OurImpactStack extends cdk.Stack {
  constructor(
    scope: Construct,
    id: string,
    props?: cdk.StackProps & {
      staging?: boolean;
    }
  ) {
    super(scope, id, props);

    // Define your constructs here
    const pool = new cdk.aws_cognito.UserPool(this, "OurImpactUserPool", {
      userPoolName: `OurImpactUserPool${props?.staging ? "Staging" : ""}`,
      selfSignUpEnabled: true,
      signInAliases: { email: true },
      userVerification: {
        emailSubject: "Verify your email for OurImpact",
        emailBody:
          "Thanks for signing up to OurImpact! Your verification code is {####}",
        emailStyle: cdk.aws_cognito.VerificationEmailStyle.CODE,
      },
    });

    pool.addClient("OurImpactUserPoolClient", {
      userPoolClientName: `OurImpactUserPoolClient${
        props?.staging ? "Staging" : ""
      }`,
      generateSecret: false,
    });
  }
}
