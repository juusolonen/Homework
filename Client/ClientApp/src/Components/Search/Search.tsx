import React, {useContext} from "react";
import "./Search.css";
import {AppProductContext} from "../../Context/AppProductContext.ts";

const Search: React.FunctionComponent = () => {

    const {filterText, setFilterText} = useContext(AppProductContext);
    
    const updateFilterText = (text: string) => {
        if (filterText == text) {
            return;
        }
        
        setFilterText(text);
    }
    
    return (
        <div className={"row mx-auto my-3 justify-content-end"}>
            <input type={"text"}
                   className={"search-input"}
                   placeholder={"Type to search..."}
                   onChange={e => updateFilterText(e.target.value)}
            />
        </div>
    )
}

export default Search;
