import React, {useEffect, useState} from "react";
import ProductCard from "../ProductCard/ProductCard.tsx";
import type {Product} from "../../Models/Product.ts";
import type {ProductsResponse} from "../../Models/ProductsResponse.ts";
import "./ProductListing.css"
import {ApiProvider} from "../../Apiprovider.ts";
import {Constants} from "../../Constants.ts";

const ProductListing: React.FunctionComponent = () => {
    const [products, setProducts] = useState<Product[]>([]);
    
    useEffect(() => {
        (async () => {
            const response = await ApiProvider.getAsync<ProductsResponse>(Constants.ApiPaths.PRODUCTS);

            setProducts(response?.products ?? []);
        })()
    }, [])
    
    
    return (
        <div className="productListing min-vh-100 row row-cols-lg-4 row-cols-xl-6 row-cols-md-4 row-cols-sm-1 g-4 mt-3">
            { products.length > 0 &&
               products.map((product: Product) => (
                   <div className="col shadow-sm px-1 mt-3 rounded cardColumn"
                        key={`product_${product.id}`}
                   >
                       <ProductCard product={product}/>
                   </div>
               ))
            }
        </div>
    )
}

export default ProductListing;
