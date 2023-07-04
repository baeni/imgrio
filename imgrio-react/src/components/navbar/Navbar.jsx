import React from 'react';
import './navbar.css';

const Navbar = () => {
  return (
    <div className="navbar">
      <div className="navbar__links">
        <div className="navbar__links-brand">
          <h1>imgrio</h1>
        </div>
        <div className="navbar__links-container">
          <p><a href="/">Home</a></p>
          <p><a href="#sharex">ShareX</a></p>
        </div>
      </div>
      <div className="navbar__sign">
        <button className="btn">Anmelden</button>
      </div>
    </div>
  )
}

export default Navbar
