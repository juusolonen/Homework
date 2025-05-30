import './App.css'
import ProductListing from "./Components/ProductListing/ProductListing.tsx";
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

  return (
    <div className="flex flex-column align-items-center">
        <div className="row">
            <div className={"page-header mb-4 pb-4"}>
                <h1>Products</h1>
            </div>
        </div>
        
        <div className={"row mx-auto my-3 justify-content-end"}>
            <input type={"text"}
                   className={"search-input"}
                   placeholder={"Search..."}
                   style={{width: "200px", marginRight: "10px"}}
            />
        </div>
  
        <ProductListing />
    </div>
  )
}

export default App;
