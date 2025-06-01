import {useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import type {Product} from "./Models/Product.ts";
import {AppContext} from "./Context/AppContext.ts";
import ProductListing from "./Components/ProductListing/ProductListing.tsx";
import PageHeader from "./Components/PageHeader/PageHeader.tsx";
import Search from "./Components/Search/Search.tsx";

function App() {
    
    const [products, setProducts] = useState<Product[]>([]);
    
    return (
    <div className="flex flex-column align-items-center">
        <AppContext.Provider value={{products, setProducts}}
        >
            <PageHeader title={"Products"}/>
            
            <Search/>
      
            <ProductListing/>
        </AppContext.Provider>
    </div>
  )
}

export default App;
