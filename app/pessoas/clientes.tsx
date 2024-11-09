import Button from "@/components/Button";
import firestore from "@/configs/firebaseConfig";
import styles from "@/constants/styles";
import { Customer } from "@/contracts/customer";
import { Ionicons } from "@expo/vector-icons";
import { Link, useFocusEffect } from "expo-router";
import { collection, getDocs } from "firebase/firestore";
import { useState } from "react";
import { ScrollView, Text, View } from "react-native";

export default function CustomersTab() {
  const [suppliers, setCustomers] = useState<Customer[]>([]);
  useFocusEffect(() => {
    fetchCustomers();
  });
  async function fetchCustomers() {
    try {
      const customersSnapshot = await getDocs(
        collection(firestore, "customers")
      );
      const customersList = customersSnapshot.docs.map((doc) => {
        const data = doc.data();
        return {
          id: doc.id || "",
          name: data.name || "",
          contact: data.contact || "",
          createdAt: data.createdAt?.toDate() || new Date(),
        } as Customer;
      });
      setCustomers(customersList);
    } catch (error) {
      console.error("Erro ao buscar clientes:", error);
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Lista de clientes</Text>
      <ScrollView style={{ gap: 10 }}>
        <View style={styles.table}>
          <View style={styles.tableRowHeader}>
            <Text style={styles.tableHeaderText}>Nome</Text>
            <Text style={styles.tableHeaderText}>Contato</Text>
          </View>

          {suppliers.map((customer, index) => (
            <View
              key={customer.id}
              style={[
                styles.tableRow,
                index % 2 === 0 ? styles.tableRowEven : styles.tableRowOdd,
              ]}
            >
              <Text style={styles.tableCell}>{customer.name}</Text>
              <Text style={styles.tableCell}>{customer.contact}</Text>
              <Link
                href={{
                  pathname: "/pessoas/clientes/[id]",
                  params: { id: customer.id as string },
                }}
              >
                <Ionicons name="eye-outline" size={15} color="#3A98FF" />
              </Link>
            </View>
          ))}
        </View>
        <Button>
          <Link
            style={[{ alignSelf: "center" }, { color: "#fff" }]}
            href="/pessoas/clientes/criar"
          >
            Adicionar
          </Link>
        </Button>
      </ScrollView>
    </View>
  );
}
("");
