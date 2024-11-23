import React from "react";
import { Link } from "react-router-dom";

const NavBar: React.FC = () => {
  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
        <Link className="navbar-brand" to="/">Home</Link>
        <div>
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
              <li className="nav-item">
                <Link to="/Tickets/Add" className="nav-link active" aria-current="page">Add Ticket</Link>
              </li>
            </ul>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;