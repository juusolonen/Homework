import './App.css'
import ProductListing from "./Components/ProductListing.tsx";
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

  return (
    <div>
          <div className={"page-header "}>
              <h1>Products</h1>
          </div>
        <ProductListing />
    </div>
  )
}

export default App;
