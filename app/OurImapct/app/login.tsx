import { Button } from "@/components/Button";
import { Logo } from "@/components/Logo";
import { TextInput } from "@/components/TextInput";
import { Link } from "expo-router";
import { useState } from "react";
import { StyleSheet, Text, View } from "react-native";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSignIn = () => {
    // TODO: Add authentication logic
    console.log("Sign in pressed", { email, password });
  };

  return (
    <View style={styles.container}>
      <Logo style={styles.logo} />

      <View style={styles.form}>
        <TextInput
          placeholder="Email"
          value={email}
          onChangeText={setEmail}
          keyboardType="email-address"
          autoCapitalize="none"
          autoComplete="email"
        />

        <TextInput
          placeholder="Password"
          value={password}
          onChangeText={setPassword}
          secureTextEntry
          autoComplete="password"
        />

        <Button onPress={handleSignIn}>
          <Text style={styles.buttonText}>Sign In</Text>
        </Button>

        <View style={styles.linkContainer}>
          <Text style={styles.linkText}>
            Don&apos;t have an account? Go to{" "}
            <Link href="/register" style={styles.link}>
              register
            </Link>
          </Text>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    paddingHorizontal: 20,
    backgroundColor: "#fff",
  },
  logo: {
    marginBottom: 60,
  },
  form: {
    width: "100%",
    maxWidth: 300,
  },
  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "600",
    textAlign: "center",
  },
  linkContainer: {
    marginTop: 20,
    alignItems: "center",
  },
  linkText: {
    fontSize: 14,
    color: "#666",
    textAlign: "center",
  },
  link: {
    color: "#007AFF",
    fontWeight: "600",
  },
});
