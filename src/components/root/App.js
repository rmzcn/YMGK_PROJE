import Navbar from '../navbar/Navbar';
import { Route, Switch,BrowserRouter } from "react-router-dom";
import ZiyaretciKaydet from '../common/ZiyaretciKaydet';
import '../../content/style.css';
import CalisanKaydet from '../common/CalisanKaydet';
import Kamera1 from '../common/Kamera1';

function App() {
  return (
    <div className="App">
     <BrowserRouter>
     <Navbar></Navbar>
     <Route path="/ziyaretcikaydet" exact component={ZiyaretciKaydet}></Route>
     <Route path="/gorevlikaydet" exact component={CalisanKaydet}></Route>
     <Route path="/kamera1" exact component={Kamera1}></Route>
     </BrowserRouter>
    </div>
  );
}

export default App;
