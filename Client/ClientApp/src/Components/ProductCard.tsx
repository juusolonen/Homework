import * as React from "react";
import type {Product} from "../Models/Product.ts";

interface ProductCardProps {
    product: Product;
}
const ProductCard: React.FunctionComponent<ProductCardProps> = (props: ProductCardProps) => {

    return (
        <div className="card" >
            <img src={props.product.imageUrl} className="card-img-top" alt="..."/>
            <div className="card-body">
                <h5 className="card-title">{props.product.title}</h5>
                <p className="card-text">{props.product.description}</p>
                <p className="card-footer">{props.product.price}</p>
            </div>
        </div>
    )
}

export default ProductCard;
