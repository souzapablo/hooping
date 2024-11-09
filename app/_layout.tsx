import { GestureHandlerRootView } from "react-native-gesture-handler";
import { Drawer } from "expo-router/drawer";
import { Ionicons } from "@expo/vector-icons";

export default function RootLayout() {
  function icon(name: any) {
    return (props: any) => (
      <Ionicons
        name={name}
        size={18}
        color={props.focused ? "#800000" : "#000"}
      />
    );
  }
  return (
    <GestureHandlerRootView style={{ flex: 1 }}>
      <Drawer
        screenOptions={{ drawerActiveTintColor: "#800000", headerShown: false }}
      >
        <Drawer.Screen
          name="index"
          options={{
            drawerLabel: "Início",
            title: "Gestão de artesanatos",
            drawerIcon: icon("storefront-outline"),
          }}
        />
        <Drawer.Screen
          name="materiais"
          options={{
            drawerLabel: "Materiais",
            title: "Materiais",
            drawerIcon: icon("cart-outline"),
          }}
        />
        <Drawer.Screen
          name="pessoas"
          options={{
            drawerLabel: "Pessoas",
            title: "Pessoas",
            drawerIcon: icon("people-circle-outline"),
          }}
        />
      </Drawer>
    </GestureHandlerRootView>
  );
}
