import React, {useContext, useEffect} from "react";
import {AppContext} from "../../Context/AppContext.ts";
import {ApiProvider} from "../../Apiprovider.ts";
import type {ProductsResponse} from "../../Models/ProductsResponse.ts";
import type {Product} from "../../Models/Product.ts";
import {Constants} from "../../Constants.ts";
import ProductCard from "../ProductCard/ProductCard.tsx";
import "./ProductListing.css"


const ProductListing: React.FunctionComponent = () => {
    
    const {products, setProducts} = useContext(AppContext);
    
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
