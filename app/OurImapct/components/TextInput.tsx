import {
  StyleSheet,
  TextInput as RNTextInput,
  TextInputProps,
} from "react-native";

export const TextInput = (props: TextInputProps) => {
  const { style, ...rest } = props;
  return <RNTextInput style={[styles.input, style]} {...rest} />;
};

const styles = StyleSheet.create({
  input: {
    borderWidth: 1,
    borderColor: "#ddd",
    borderRadius: 8,
    paddingHorizontal: 15,
    paddingVertical: 12,
    marginBottom: 20,
    fontSize: 16,
  },
});
