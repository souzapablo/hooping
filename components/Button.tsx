import { Pressable } from "react-native";
import { StyleSheet } from "react-native";

export interface ButtonProps {
  children: React.ReactNode;
  onPress?: () => void;
  small?: boolean;
  right?: boolean;
}

export default function Button(props: ButtonProps) {
  return (
    <Pressable
      style={({ pressed }) => [
        { opacity: pressed ? 0.8 : 1 },
        styles.button,
        props.small ? styles.small : null,
        props.right ? styles.right : null,
      ]}
      onPress={props.onPress}
    >
      {props.children}
    </Pressable>
  );
}

const styles = StyleSheet.create({
  button: {
    backgroundColor: "#800000",
    paddingHorizontal: 15,
    paddingVertical: 10,
    borderRadius: 5,
  },
  small: {
    width: "15%",
  },
  right: {
    alignSelf: "flex-end",
    alignContent: "center",
  },
});
