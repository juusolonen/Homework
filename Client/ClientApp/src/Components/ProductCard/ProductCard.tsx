import * as React from "react";
import type {Product} from "../../Models/Product.ts";
import "./ProductCard.css";

interface ProductCardProps {
    product: Product;
}
const ProductCard: React.FunctionComponent<ProductCardProps> = (props: ProductCardProps) => {

    return (
        <div className="card productCard mx-auto" >
            <img src={props.product.imageUrl} className="card-img-top mx-auto image" alt="..."/>
            <div className="card-body">
                <h5 className="card-title">{props.product.title}</h5>
                <p className="card-text" style={{fontSize: '12px'}}>{props.product.description.length > 100 ? props.product.description.substring(0,100) + "..." : props.product.description}</p>
                <p className="card-footer fw-semibold" style={{fontSize: '12px'}}>{props.product.price}</p>
            </div>
        </div>
    )
}

export default ProductCard;
