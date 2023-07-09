import React, { useState, useEffect } from 'react';
import './navbar.css';

import { useMsal, AuthenticatedTemplate, UnauthenticatedTemplate } from '@azure/msal-react';
import { loginRequest } from '../../authConfig';

const Navbar = () => {
  const { instance } = useMsal();
  let activeAccount;

  if (instance) {
    activeAccount = instance.getActiveAccount();
  }

    const handleLogin = async () => {
        try {
            await instance.loginPopup(loginRequest);
        } catch (error) {
            console.error('Login error:', error);
        }
    };

    const handleLogout = async () => {
        try {
            await instance.logoutRedirect();
        } catch (error) {
            console.error('Logout error:', error);
        }
    };

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
        <AuthenticatedTemplate>
          <button className="btn" onClick={handleLogout}>Abmelden</button>
        </AuthenticatedTemplate>
        <UnauthenticatedTemplate>
          <button className="btn" onClick={handleLogin}>Anmelden</button>
        </UnauthenticatedTemplate>
      </div>
    </div>
  )
}

export default Navbar
