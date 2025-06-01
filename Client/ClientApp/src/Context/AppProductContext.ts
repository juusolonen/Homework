import {createContext} from "react";
import type {Product} from "../Models/Product.ts";

export interface IAppProductContext {
    products: Product[],
    filterText: string | null,
    setFilterText: (text: string | null) => void;
}

export const context: IAppProductContext = {  
    products: [],
    filterText: null,
    setFilterText: () => {},
};

export const AppProductContext = createContext<IAppProductContext>(context);  