import React from "react";
import "./Search.css";

const Search: React.FunctionComponent = () => {
    return (
        <div className={"row mx-auto my-3 justify-content-end"}>
            <input type={"text"}
                   className={"search-input"}
                   placeholder={"Search..."}
            />
        </div>
    )
}

export default Search;
