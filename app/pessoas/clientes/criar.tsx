import Button from "@/components/Button";
import styles from "@/constants/styles";
import { useState } from "react";
import { Text, View } from "react-native";
import { TextInput } from "react-native-gesture-handler";
import { collection, addDoc } from "firebase/firestore";
import firestore from "@/configs/firebaseConfig";
import { useRouter } from "expo-router";
import { Customer } from "@/contracts/customer";

export default function CreateCustomer() {
  const [customer, setCustomer] = useState<Customer>({
    name: "",
    contact: "",
    createdAt: new Date(),
  });
  const [errors, setErrrors] = useState<any>({});
  const router = useRouter();

  function validate() {
    let errors = {};

    if (!customer?.name)
      errors = { ...errors, name: "O nome do cliente é obrigatório." };

    if (customer?.name && customer.name.length < 2) {
      errors = {
        ...errors,
        name: "O nome do cliente deve ter pelo menos 2 caracteres.",
      };
    }

    if (!customer?.contact)
      errors = { ...errors, contact: "O contato do cliente é obrigatório." };

    if (customer?.contact && customer.contact.length < 3) {
      errors = {
        ...errors,
        contact: "O contato do cliente deve ter pelo menos 3 caracteres.",
      };
    }

    setErrrors(errors);

    return Object.keys(errors).length === 0;
  }

  async function save() {
    if (validate()) {
      try {
        await addDoc(collection(firestore, "customers"), customer);
        router.push("/pessoas/clientes");
        setCustomer({
          id: "",
          name: "",
          contact: "",
          createdAt: new Date(),
        });
      } catch (error) {
        console.error("Erro ao salvar o cliente:", error);
        alert("Erro ao salvar o cliente. Tente novamente.");
      }
    }
  }
  return (
    <View style={styles.center}>
      <Text style={styles.title}> Criar cliente</Text>
      <Text style={styles.label}>Nome</Text>
      <TextInput
        placeholder="Nome"
        value={customer.name ?? ""}
        style={[styles.input, errors.name ? styles.inputError : null]}
        onChangeText={(name) => setCustomer({ ...customer, name })}
      />
      {errors.name && <Text style={styles.inputError}>{errors.name}</Text>}

      <Text style={styles.label}>Contato</Text>
      <TextInput
        placeholder="Contato"
        value={customer.contact ?? ""}
        style={[styles.input, errors.contact ? styles.inputError : null]}
        onChangeText={(contact) => setCustomer({ ...customer, contact })}
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
