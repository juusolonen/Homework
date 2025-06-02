import "./ProductCard.css";
import React, {useEffect, useState} from "react";
import type {Product} from "../../Models/Product.ts";
import {Utility} from "../../Utility.ts";
import Card from "../Card/Card.tsx";

interface ProductCardProps {
    product: Product;
}
const ProductCard: React.FunctionComponent<ProductCardProps> = ({product: {thumbnail, title, price, description}}: ProductCardProps) => {

    const [imageLoaded, setImageLoaded] = useState(false);
    
    useEffect(() => {
        const image = new Image();
        image.onload = () => setImageLoaded(true);
        image.src = thumbnail;
        
        return () => {
            image.onload = null;
        }
    }, [])
    
    const renderContent = (): React.ReactNode => {
         
        if (!imageLoaded) {
            return (
                <div className="card product-card mx-auto pg-placeholder"/>
            )
        }
        
        return (
            <>
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
            </>
        )
    }
    const renderOnHover = (): React.ReactNode => {
        return (
            <div className="card product-card mx-auto pg-placeholder">
                {description}
            </div>    
        )
    }
    
    return (
        <Card renderContent={() => renderContent()} 
              renderOnHover={() => renderOnHover()}
        />
    )
}

export default ProductCard;
