import React, { Component } from 'react'
import { BrowserRouter,Route,Routes,NavLink } from 'react-router-dom'
import Home from './Home'
import Services from './Services'
import Projects from './Projects'
import Contact from './Contact'


 class Navbar extends Component {
  render() {
    return (
        <BrowserRouter>
        <div className="App container">
           
            <nav className="navbar navbar-expand-sm bg-light navbar-dark">
                <ul className="navbar-nav">
                    <li className="nav-item- m-1">
                        <NavLink className="btn btn-light btn-outline-primary" to="/Home">
                            Home
                        </NavLink>
                    </li>
                    <li className="nav-item- m-1">
                        <NavLink className="btn btn-light btn-outline-primary" to="/Projects">
                            Projects
                        </NavLink>
                    </li>
                    <li className="nav-item- m-1">
                        <NavLink className="btn btn-light btn-outline-primary" to="/Services">
                            Services
                        </NavLink>
                    </li>
                    <li className="nav-item- m-1">
                        <NavLink className="btn btn-light btn-outline-primary" to="/Contact">
                            Contact
                        </NavLink>
                    </li>
                  
                </ul>
            </nav>

            <Routes>
                <Route path="/Home" element={ <Home /> } />
                <Route path="/Projects" element={ <Projects /> } />
                <Route path="/Services" element={ <Services /> } />
                <Route path="/Contact" element={ <Contact /> } />
            </Routes>
        </div>
    </BrowserRouter>
    )
  }
}

export default Navbar