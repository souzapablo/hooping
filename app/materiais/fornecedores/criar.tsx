import Button from "@/components/Button";
import styles from "@/constants/styles";
import { useState } from "react";
import { Text, View } from "react-native";
import { TextInput } from "react-native-gesture-handler";
import { collection, addDoc } from "firebase/firestore";
import firestore from "@/configs/firebaseConfig";
import { useRouter } from "expo-router";
import { Supplier } from "@/contracts/supplier";

export default function SuppliersTab() {
  const [supplier, setSupplier] = useState<Supplier>({
    name: "",
    contact: "",
    createdAt: new Date(),
    products: [],
  });
  const [errors, setErrrors] = useState<any>({});
  const router = useRouter();

  function validate() {
    let errors = {};

    if (!supplier?.name)
      errors = { ...errors, name: "O nome do fornecedor é obrigatório." };

    if (supplier?.name && supplier.name.length < 3) {
      errors = {
        ...errors,
        name: "O nome do fornecedor deve ter pelo menos 3 caracteres.",
      };
    }

    if (!supplier?.contact)
      errors = { ...errors, contact: "O contato do fornecedor é obrigatório." };

    if (supplier?.contact && supplier.contact.length < 3) {
      errors = {
        ...errors,
        contact: "O contato do fornecedor deve ter pelo menos 3 caracteres.",
      };
    }

    setErrrors(errors);

    return Object.keys(errors).length === 0;
  }

  async function save() {
    if (validate()) {
      try {
        await addDoc(collection(firestore, "suppliers"), supplier);
        router.push("/materiais/fornecedores");
        setSupplier({
          id: "",
          name: "",
          contact: "",
          createdAt: new Date(),
          products: [],
        });
      } catch (error) {
        console.error("Erro ao salvar o fornecedor:", error);
        alert("Erro ao salvar o fornecedor. Tente novamente.");
      }
    }
  }
  return (
    <View style={styles.center}>
      <Text style={styles.title}> Criar fornecedor</Text>
      <Text style={styles.label}>Nome</Text>
      <TextInput
        placeholder="Nome"
        value={supplier.name ?? ""}
        style={[styles.input, errors.name ? styles.inputError : null]}
        onChangeText={(name) => setSupplier({ ...supplier, name })}
      />
      {errors.name && <Text style={styles.inputError}>{errors.name}</Text>}

      <Text style={styles.label}>Contato</Text>
      <TextInput
        placeholder="Contato"
        value={supplier.contact ?? ""}
        style={[styles.input, errors.contact ? styles.inputError : null]}
        onChangeText={(contact) => setSupplier({ ...supplier, contact })}
      />
      {errors.contact && (
        <Text style={styles.inputError}>{errors.contact}</Text>
      )}

      <Button onPress={save}>
        <Text style={{ color: "#fff" }}> Salvar </Text>
      </Button>
    </View>
  );
}
