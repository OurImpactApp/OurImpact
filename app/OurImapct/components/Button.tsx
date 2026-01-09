import { TouchableOpacity, TouchableOpacityProps } from "react-native";

export const Button = (props: TouchableOpacityProps) => {
  const { children, onPress } = props;
  return (
    <TouchableOpacity style={styles.button} onPress={onPress}>
      {children}
    </TouchableOpacity>
  );
};

const styles = {
  button: {
    backgroundColor: "#007AFF",
    paddingHorizontal: 30,
    paddingVertical: 15,
    borderRadius: 8,
  },
};
