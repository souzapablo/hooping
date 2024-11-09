import { Product } from "./product";

export interface Supplier {
  id?: string;
  name: string;
  contact: string;
  createdAt: Date;
  products: Product[];
}
