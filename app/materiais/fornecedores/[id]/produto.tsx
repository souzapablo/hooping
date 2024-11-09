import Button from "@/components/Button";
import firestore from "@/configs/firebaseConfig";
import styles from "@/constants/styles";
import { Product } from "@/contracts/product";
import { useLocalSearchParams, useRouter } from "expo-router";
import {
  addDoc,
  arrayUnion,
  collection,
  doc,
  updateDoc,
} from "firebase/firestore";
import { useState } from "react";
import { Text, TextInput, View } from "react-native";

export default function CreateProduct() {
  const { id } = useLocalSearchParams();
  const [product, setProduct] = useState<Product>({
    description: "",
    price: 0,
  });
  const [inputValue, setInputValue] = useState<string>("");
  const [errors, setErrrors] = useState<any>({});
  const router = useRouter();
  function validate() {
    let errors = {};

    if (!product?.description)
      errors = {
        ...errors,
        description: "A descrição do produto é obrigatória.",
      };

    if (product?.description && product.description.length < 3) {
      errors = {
        ...errors,
        description: "A descrição do produto deve ter pelo menos 3 caracteres.",
      };
    }

    if (!product?.price)
      errors = { ...errors, price: "O preço é obrigatório." };

    if (product?.price && product.price <= 0) {
      errors = {
        ...errors,
        contact: "Preço inválido.",
      };
    }

    setErrrors(errors);

    return Object.keys(errors).length === 0;
  }
  function handleChange(text: string) {
    const validValue = text.replace(/[^0-9.]/g, "");

    if ((validValue.match(/\./g) || []).length > 1) return;

    setInputValue(validValue);
    setProduct({
      ...product,
      price: validValue === "" ? 0 : parseFloat(validValue),
    });
  }
  async function save() {
    if (validate()) {
      try {
        const supplierDoc = doc(firestore, "suppliers", id as string);

        const productId = doc(collection(firestore, "products")).id;

        const productData = {
          id: productId,
          ...product,
        };

        await updateDoc(supplierDoc, {
          products: arrayUnion(productData),
        });

        router.push(`/materiais/fornecedores/${id}`);
        setProduct({
          description: "",
          price: 0,
        });
      } catch (error) {
        console.error("Erro ao salvar o produto:", error);
        alert("Erro ao salvar o produto. Tente novamente.");
      }
    }
  }
  return (
    <View style={styles.center}>
      <Text style={styles.title}> Criar produto</Text>
      <Text style={styles.label}>Descrição</Text>
      <TextInput
        placeholder="Descrição"
        value={product.description ?? ""}
        style={[styles.input, errors.name ? styles.inputError : null]}
        onChangeText={(description) => setProduct({ ...product, description })}
      />
      {errors.name && <Text style={styles.inputError}>{errors.name}</Text>}

      <Text style={styles.label}>Preço</Text>
      <TextInput
        style={styles.input}
        onChangeText={handleChange}
        value={inputValue}
        keyboardType="numeric"
        placeholder="Enter numbers only"
        placeholderTextColor="#999"
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
