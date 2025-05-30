import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import ProductListing from "./Components/ProductListing/ProductListing.tsx";
import PageHeader from "./Components/PageHeader/PageHeader.tsx";
import Search from "./Components/Search/Search.tsx";

function App() {

  return (
    <div className="flex flex-column align-items-center">
        
        <PageHeader title={"Products"}/>
        
        <Search/>
  
        <ProductListing />
    </div>
  )
}

export default App;
