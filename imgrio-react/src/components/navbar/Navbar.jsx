import React, { useState, useEffect } from 'react';
import './navbar.css';

import { useMsal } from '@azure/msal-react';
import { loginRequest } from '../../authConfig';

const Navbar = () => {
  const { instance } = useMsal();
  const [authenticated, setAuthenticated] = useState(false);

  useEffect(() => {
    const checkAuthentication = async () => {
      try {
        console.info('test');
        const response = await instance.acquireTokenSilent(loginRequest);
        console.info(response.accessToken);
        setAuthenticated(true);
      } catch (error) {
        setAuthenticated(false);
      }
    };

    checkAuthentication();
  }, [instance]);

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
        {
          authenticated
          ? (<button className="btn" onClick={handleLogout}>Abmelden</button>)
          : (<button className="btn" onClick={handleLogin}>Anmelden</button>)
        }
      </div>
    </div>
  )
}

export default Navbar
