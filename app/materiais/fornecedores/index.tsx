import Button from "@/components/Button";
import firestore from "@/configs/firebaseConfig";
import styles from "@/constants/styles";
import { Supplier } from "@/contracts/supplier";
import { Ionicons } from "@expo/vector-icons";
import { Link, useFocusEffect } from "expo-router";
import { collection, getDocs } from "firebase/firestore";
import { useState } from "react";
import { ScrollView, Text, View } from "react-native";

export default function SuppliersTab() {
  const [suppliers, setSuppliers] = useState<Supplier[]>([]);
  useFocusEffect(() => {
    fetchSuppliers();
  });
  async function fetchSuppliers() {
    try {
      const suppliersSnapshot = await getDocs(
        collection(firestore, "suppliers")
      );
      const suppliersList = suppliersSnapshot.docs.map((doc) => {
        const data = doc.data();
        return {
          id: doc.id || "",
          name: data.name || "",
          contact: data.contact || "",
          createdAt: data.createdAt?.toDate() || new Date(),
        } as Supplier;
      });
      setSuppliers(suppliersList);
    } catch (error) {
      console.error("Erro ao buscar fornecedores:", error);
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Lista de fornecedores</Text>
      <ScrollView style={{ gap: 10 }}>
        <View style={styles.table}>
          <View style={styles.tableRowHeader}>
            <Text style={styles.tableHeaderText}>Nome</Text>
            <Text style={styles.tableHeaderText}>Contato</Text>
          </View>

          {suppliers.map((supplier, index) => (
            <View
              key={supplier.id}
              style={[
                styles.tableRow,
                index % 2 === 0 ? styles.tableRowEven : styles.tableRowOdd,
              ]}
            >
              <Text style={styles.tableCell}>{supplier.name}</Text>
              <Text style={styles.tableCell}>{supplier.contact}</Text>
              <Link
                href={{
                  pathname: "/materiais/fornecedores/[id]",
                  params: { id: supplier.id as string },
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
            href="/materiais/fornecedores/criar"
          >
            Adicionar
          </Link>
        </Button>
      </ScrollView>
    </View>
  );
}
("");
