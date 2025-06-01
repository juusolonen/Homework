import "./Card.css";
import React, {useState} from "react";

interface CardProps {
    renderContent: () => React.ReactNode;
    renderOnHover: () => React.ReactNode;
}
const Card: React.FunctionComponent<CardProps> = ({renderContent, renderOnHover}) => {

    const [hover, setHover] = useState(false);
    
    return (
        <div className="card genericCard mx-auto" 
             onMouseEnter={() => setHover(true)}
             onMouseLeave={() => setHover(false)}
        >
            {hover ? renderOnHover() : renderContent()}
        </div>
    )
}

export default Card;
