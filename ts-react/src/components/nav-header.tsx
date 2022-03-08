import * as React from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import Logo from "../logo.svg";
import LoggedIn from "./loggedin";

const NavHeader = (props: any) => {
  const [isNavCollapsed, setIsNavCollapsed] = useState(true);

  const handleNavCollapse = () => setIsNavCollapsed(!isNavCollapsed);

  return (
    <nav className="navbar navbar-expand-sm bg-dark navbar-dark">
      <div className="container-fluid">
        <a className="navbar-brand" href="#">
          <img src={Logo} alt="Xcelvations Logo" height="35" />
        </a>
        <button
          title="toggle"
          onClick={handleNavCollapse}
          type="button"
          data-target="#navbarCollapse"
          className="navbar-toggler"
          data-bs-toggle="collapse"
          data-bs-target="#navbarCollapse"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div
          className={`${isNavCollapsed ? "collapse" : ""} navbar-collapse`}
          id="navbarCollapse"
        >
          <ul className="navbar-nav">
            <li className="nav-item active">
              <Link to="/" className="nav-link">
                Home
              </Link>
            </li>

            <li className="nav-item">
              <Link to="/about" className="nav-link">
                about
              </Link>
            </li>

            <li className="nav-item">
              <Link to="/miss" className="nav-link">
                miss
              </Link>
            </li>
          </ul>
          <LoggedIn />
        </div>{" "}
      </div>
    </nav>
  );
};

export default NavHeader;
