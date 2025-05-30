import * as React from "react";
import ProductCard from "../ProductCard/ProductCard.tsx";
import type {Product} from "../../Models/Product.ts";
import "./ProductListing.css"

const ProductListing: React.FunctionComponent = () => {
    
    const product: Product =  {
        description: "The Essence Mascara Lash Princess is a popular mascara known for its volumizing and lengthening effects. Achieve dramatic lashes with this long-lasting and cruelty-free formula.",
        id: 0,
        imageUrl: "https://cdn.dummyjson.com/product-images/beauty/essence-mascara-lash-princess/thumbnail.webp",
        price: 9.99,
        title: "Essence Mascara Lash Princess"
    } ;
    
    return (
        <div className="productListing row row-cols-lg-6 row-cols-md-4 row-cols-sm-1 g-4 mt-3">
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
            <div className="col shadow-sm px-1 mt-3 rounded cardColumn">
                <ProductCard product={product}/>
            </div>
        </div>
    )
}

export default ProductListing;
