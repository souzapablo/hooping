import {
  Link,
  useFocusEffect,
  useLocalSearchParams,
  useRouter,
} from "expo-router";
import { useCallback, useEffect, useState } from "react";
import { Text, View, ScrollView } from "react-native";
import firestore from "@/configs/firebaseConfig";
import { doc, DocumentData, getDoc, Timestamp } from "firebase/firestore";
import styles from "@/constants/styles";
import Button from "@/components/Button";
import { Supplier } from "@/contracts/supplier";
import { Ionicons } from "@expo/vector-icons";

export default function SupplierDetails() {
  const router = useRouter();
  const { id } = useLocalSearchParams();
  useFocusEffect(() => {
    fetchSupplierDetails(id);
  });
  const [supplier, setSupplier] = useState<Supplier>({
    id: "",
    name: "",
    contact: "",
    createdAt: new Date(),
    products: [],
  });

  useFocusEffect(
    useCallback(() => {
      if (id && typeof id === "string") {
        fetchSupplierDetails(id);
      } else {
        console.error("Invalid or missing supplier ID.");
      }
    }, [id])
  );

  async function fetchSupplierDetails(supplierId: string) {
    try {
      const supplierDoc = await getDoc(doc(firestore, "suppliers", supplierId));
      if (supplierDoc.exists()) {
        const data = supplierDoc.data() as DocumentData;

        const supplierData: Supplier = {
          id: supplierId,
          name: data.name || "",
          contact: data.contact || "",
          createdAt: data.createdAt ? data.createdAt.toDate() : new Date(),
          products: data.products || [],
        };

        setSupplier(supplierData);
      } else {
        console.log("No such supplier!");
      }
    } catch (error) {
      console.error("Erro ao buscar fornecedor:", error);
    }
  }

  if (!supplier) {
    return (
      <View style={styles.container}>
        <Text>Loading...</Text>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Detalhes do Fornecedor</Text>
      <ScrollView>
        <View style={styles.detailCard}>
          <Text style={styles.detailText}>Nome: {supplier.name}</Text>
          <Text style={styles.detailText}>Contato: {supplier.contact}</Text>
          <Text style={styles.detailText}>
            Data de cadastro:{" "}
            {supplier.createdAt.toLocaleDateString() ?? "Data inválida"}
          </Text>
        </View>
        <Text style={styles.title}>Produtos</Text>
        <Button small right>
          <Link
            href={{
              pathname: "/materiais/fornecedores/[id]/produto",
              params: { id: supplier.id as string },
            }}
          >
            <Ionicons
              name="add-outline"
              style={[{ alignSelf: "center" }, { color: "#fff" }]}
            />
          </Link>
        </Button>
        <View style={styles.table}>
          <View style={styles.tableRowHeader}>
            <Text style={styles.tableHeaderText}>Descrição</Text>
            <Text style={styles.tableHeaderText}>Preço</Text>
          </View>

          {supplier.products.map((product, index) => (
            <View
              key={product.id}
              style={[
                styles.tableRow,
                index % 2 === 0 ? styles.tableRowEven : styles.tableRowOdd,
              ]}
            >
              <Text style={styles.tableCell}>{product.description}</Text>
              <Text style={styles.tableCell}>R$ {product.price}</Text>
            </View>
          ))}
        </View>
        <Button onPress={() => router.back()}>
          <Text style={[{ alignSelf: "center" }, { color: "#fff" }]}>
            Voltar
          </Text>
        </Button>
      </ScrollView>
    </View>
  );
}
