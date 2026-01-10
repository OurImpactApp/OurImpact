import { Button } from "@/components/Button";
import { Logo } from "@/components/Logo";
import { useRouter } from "expo-router";
import { useCallback } from "react";
import { StyleSheet, Text, View } from "react-native";

export default function Index() {
  const router = useRouter();
  const handleGetStarted = useCallback(() => {
    router.push("/login");
  }, [router]);

  return (
    <View style={styles.container}>
      <Logo style={styles.logo} />
      <Text style={styles.description}>Our Impact, Together</Text>
      <Button onPress={handleGetStarted}>
        <Text style={styles.buttonText}>Get Started</Text>
      </Button>
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
    marginBottom: 40,
  },
  description: {
    fontSize: 16,
    marginBottom: 60,
    textAlign: "center",
    color: "#666",
  },
  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "600",
  },
});
