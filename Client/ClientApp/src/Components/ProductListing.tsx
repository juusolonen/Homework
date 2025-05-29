import * as React from "react";
import ProductCard from "./ProductCard.tsx";
import type {Product} from "../Models/Product.ts";

const ProductListing: React.FunctionComponent = () => {
    
    const product: Product =  {
        description: 'this is a description',
        id: 0,
        imageUrl: "https://cdn.dummyjson.com/product-images/groceries/juice/thumbnail.webp",
        price: 999,
        title: 'title'
    } ;
    
    return (
        <div className="row rox-cols-6 justify-content-between">
            <div className="col">
                <ProductCard product={product}/>
            </div>
        </div>
    )
}

export default ProductListing;
