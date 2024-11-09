import { Ionicons } from "@expo/vector-icons";
import { Tabs, useNavigation } from "expo-router";

export default function Layout(props: any) {
  const nav: any = useNavigation();
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
    <Tabs
      screenOptions={{ tabBarActiveTintColor: "#800000", headerShown: false }}
    >
      <Tabs.Screen
        name="fornecedores/index"
        options={{
          title: "Fornecedores",
          tabBarIcon: icon("storefront-outline"),
        }}
      />
      <Tabs.Screen
        name="estoque"
        options={{
          title: "Estoque",
          tabBarIcon: icon("file-tray-full-outline"),
        }}
      />
      <Tabs.Screen
        name="mais"
        options={{
          tabBarIcon: icon("menu"),
          tabBarLabel: "",
        }}
        listeners={{
          tabPress: (e) => {
            e.preventDefault();
            nav?.openDrawer();
          },
        }}
      />
      <Tabs.Screen
        name="fornecedores/criar"
        options={{
          href: null,
        }}
      />
      <Tabs.Screen
        name="fornecedores/[id]"
        options={{
          href: null,
        }}
      />
      <Tabs.Screen
        name="fornecedores/[id]/produto"
        options={{
          href: null,
        }}
      />
    </Tabs>
  );
}
