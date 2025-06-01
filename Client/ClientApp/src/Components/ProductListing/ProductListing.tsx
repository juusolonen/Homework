import React, {useContext} from "react";
import {AppProductContext} from "../../Context/AppProductContext.ts";
import Listing from "../Listing/Listing.tsx";
import ProductCard from "../ProductCard/ProductCard.tsx";
import type {Product} from "../../Models/Product.ts";

const ProductListing: React.FunctionComponent = () => {
    
    const {products, filterText} = useContext(AppProductContext);
    
    const renderCallback = (product: Product) => {
        return (<ProductCard product={product}/>);
    }
    
    return (
        <Listing items={products}
                 filterText={filterText}
                 filterKey={"title"}
                 renderItem={(product: Product) => renderCallback(product)}
        />    
    )
}

export default ProductListing;
