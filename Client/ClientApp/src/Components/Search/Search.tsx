import React, {useContext} from "react";
import "./Search.css";
import {AppProductContext} from "../../Context/AppProductContext.ts";
import {Utility} from "../../Utility.ts";

const Search: React.FunctionComponent = () => {

    const {filterText, setFilterText} = useContext(AppProductContext);
    let _searchTimeout: NodeJS.Timeout | null = null;
    
    const updateFilterText = (text: string) => {
        if (filterText == text) {
            return;
        }
        
        if (_searchTimeout !== null) {
            clearTimeout(_searchTimeout);
        }
        
        _searchTimeout = Utility.debounce(() => setFilterText(text), 200);
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
