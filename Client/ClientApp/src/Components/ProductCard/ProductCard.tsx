import React from "react";
import type {Product} from "../../Models/Product.ts";
import {Utility} from "../../Utility.ts";
import "./ProductCard.css";

interface ProductCardProps {
    product: Product;
}
const ProductCard: React.FunctionComponent<ProductCardProps> = ({product: {thumbnail, title, price, description}}: ProductCardProps) => {

    return (
        <div className="card productCard mx-auto" >
            
            <img className="card-img-top mx-auto image"
                 alt={title}
                 src={thumbnail}
            />
            
            <div className="card-body">
                <h5 className="card-title">{title}</h5>
                
                <p className="card-text font12">
                    {Utility.truncate(description,100)}
                </p>
                
                <p className="card-footer fw-semibold font12">
                    {price}
                </p>
            </div>
        </div>
    )
}

export default ProductCard;
