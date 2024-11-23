import React from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";
// Bootstrap Bundle JS
import "bootstrap/dist/js/bootstrap.bundle.min";
import 'mdb-ui-kit/css/mdb.min.css';

import './App.css';
import NavBar from './Components/NavBar';
import Home from './Pages/Home';
import NotFound from './Pages/NotFound';
import AddTicket from './Pages/AddTicket';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <NavBar/>
      
          <Routes>
            <Route path='/' Component={() => <Home />}/>
            <Route path='/Tickets/Add' Component={AddTicket} />
            <Route path="*" Component={NotFound} />
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
