import {createContext} from "react";
import type {Product} from "../Models/Product.ts";

export interface IAppContext {
    products: Product[]
    setProducts: (products: Product[]) => void;
}

export const context: IAppContext = {  
    products: [],
    setProducts: () => {},
};

export const AppContext = createContext<IAppContext>(context);  