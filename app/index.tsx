import Button from "@/components/Button";
import styles from "@/constants/styles";
import { Ionicons } from "@expo/vector-icons";
import { Text, View } from "react-native";
import { useNavigation } from "expo-router";
import { DrawerActions } from "@react-navigation/native";

export default function Index() {
  const nav = useNavigation();
  return (
    <View
      style={[styles.center, [{ backgroundColor: "#fcfbf4" }, { gap: 10 }]]}
    >
      <Ionicons name="color-palette-outline" size={100} color={"#800000"} />
      <View style={[{ alignItems: "center" }, { gap: 10 }]}>
        <Text style={{ fontSize: 20, fontWeight: 700 }}>
          Gerencie seus artesantos
        </Text>
        <Text style={{ fontSize: 16 }}>
          Cadastre fornecedores, produtos e clientes
        </Text>
        <Button onPress={() => nav.dispatch(DrawerActions.openDrawer())}>
          <Text style={{ color: "#fff" }}>Gerenciar</Text>
        </Button>
      </View>
    </View>
  );
}
