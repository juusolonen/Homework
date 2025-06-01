import type {Product} from "./Product.ts";
export interface ProductsResponse {
    products: Product[];
    total: number;
}