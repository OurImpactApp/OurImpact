import * as cdk from "aws-cdk-lib";
import { OurImpactStack } from "./lib/OurImpactStack";

// Ensure DEPLOYMENT_SUFFIX is set to 'staging' until production is ready
if (process.env.DEPLOYMENT_SUFFIX !== "staging") {
  throw new Error(
    "DEPLOYMENT_SUFFIX environment variable is not set to 'staging'"
  );
}
const staging = process.env.DEPLOYMENT_SUFFIX === "staging";

const app = new cdk.App();
new OurImpactStack(app, `OurImpactStack${staging ? "Staging" : ""}`, {
  staging,
});
