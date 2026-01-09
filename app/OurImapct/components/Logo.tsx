import { StyleSheet, Text, TextProps } from "react-native";

export const Logo = (props: TextProps) => {
  const { style, ...rest } = props;
  return (
    <Text style={[styles.logo, style]} {...rest}>
      LOGO GOES HERE
    </Text>
  );
};

const styles = StyleSheet.create({
  logo: {
    fontSize: 32,
    fontWeight: "bold",
    textAlign: "center",
  },
});
