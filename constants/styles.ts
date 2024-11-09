import { StyleSheet } from "react-native";

const styles = StyleSheet.create({
  center: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
  },
  input: {
    borderWidth: 1,
    borderColor: "#000",
    borderRadius: 5,
    padding: 10,
    margin: 10,
    width: "80%",
  },
  container: {
    flex: 1,
    padding: 16,
    backgroundColor: "#f5f5f5",
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
    textAlign: "center",
  },
  table: {
    borderWidth: 1,
    borderColor: "#ddd",
    borderRadius: 4,
    overflow: "hidden",
  },
  tableRowHeader: {
    flexDirection: "row",
    backgroundColor: "#800000",
    paddingVertical: 10,
  },
  tableRow: {
    flexDirection: "row",
    paddingVertical: 12,
    paddingHorizontal: 10,
  },
  tableRowEven: {
    backgroundColor: "#f9f9f9",
  },
  tableRowOdd: {
    backgroundColor: "#fff",
  },
  tableHeaderText: {
    flex: 1,
    fontWeight: "bold",
    color: "#fff",
    textAlign: "center",
  },
  tableCell: {
    flex: 1,
    textAlign: "center",
    color: "#333",
  },
  label: {
    fontSize: 16,
    fontWeight: "bold",
    marginBottom: 5,
  },
  inputError: {
    color: "red",
    borderColor: "red",
  },
  scrollContainer: {
    paddingBottom: 20,
  },
  detailCard: {
    backgroundColor: "#fff",
    borderRadius: 10,
    padding: 15,
    marginBottom: 15,
    shadowColor: "#000",
    shadowOpacity: 0.1,
    shadowRadius: 5,
    elevation: 3,
  },
  detailText: {
    fontSize: 16,
    marginBottom: 10,
    color: "#555",
  },
});

export default styles;
