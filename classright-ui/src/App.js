import logo from './logo.svg';
import './App.css';
import { BrowserRouter } from 'react-router-dom';
import Header from './Components/Header';
import { Routes, Route } from 'react-router-dom';
import Index from './Components/Pages/Index';
import Login from './Components/Pages/Login';
import { useState } from 'react';
function App() {
  const [routes, setRoutes] = useState({});
  if (Object.keys(routes).length == 0) {
    setRoutes({
      headerRoutes: [
        {home: "/"},
        { blog: "/blog" }, 
        {projects: "/projects"}, 
        {resume: "https://docs.google.com/document/d/1OOGM1du0jJpJPz5RKPRxtHzRWd-HGRcvdk8Z3SWdnaw/edit?usp=sharing"},
      ]
    })
  }

  return (
    
    <BrowserRouter>
    <Header routes={routes}/>
    <Routes>
      <Route path='/' element={<Index />}/>
      <Route path='/login' element={<Login />}/>
    </Routes>
  </BrowserRouter>
  
  );
}

export default App;
