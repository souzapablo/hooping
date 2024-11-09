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
        name="clientes"
        options={{
          title: "Clientes",
          tabBarIcon: icon("people-outline"),
        }}
      />
      <Tabs.Screen
        name="mais"
        options={{
          tabBarIcon: icon("menu"),
        }}
        listeners={{
          tabPress: (e) => {
            e.preventDefault();
            nav?.openDrawer();
          },
        }}
      />
      <Tabs.Screen
        name="clientes/criar"
        options={{
          href: null,
        }}
      />
    </Tabs>
  );
}
