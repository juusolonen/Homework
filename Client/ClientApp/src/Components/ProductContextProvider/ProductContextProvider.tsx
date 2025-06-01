import React, {type ReactNode, useEffect, useState} from "react";
import type {Product} from "../../Models/Product.ts";
import { AppProductContext } from "../../Context/AppProductContext.ts";
import {ApiProvider} from "../../Apiprovider.ts";
import type {ProductsResponse} from "../../Models/ProductsResponse.ts";
import {Constants} from "../../Constants.ts";

interface IProductContextProps {
    children?: ReactNode;
}

const ProductContextProvider: React.FunctionComponent<IProductContextProps> = (props) => {

    const [products, setProducts] = useState<Product[]>([]);
    const [filterText, setFilterText] = useState<string|null>(null);

    useEffect(() => {
        (async () => {
            const response = await ApiProvider.getAsync<ProductsResponse>(Constants.ApiPaths.PRODUCTS);

            setProducts(response?.products ?? []);
        })()
    }, [])

    return (
        <AppProductContext.Provider value={{
                products,
                filterText,
                setFilterText
            }}>
            {props.children}
        </AppProductContext.Provider>
    )
}

export default ProductContextProvider;
