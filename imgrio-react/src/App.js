import React from 'react';

import './App.css';

import { Navbar } from './components';
import { Header, ShareX } from './containers';

import { MsalProvider, msalInstance } from './authConfig';

const App = () => {
  return (
    <MsalProvider instance={msalInstance}>
      <div className="App">
        <div className="gradient__bg">
            <Navbar />
            <Header />
        </div>
        <ShareX />
      </div>
    </MsalProvider>
  )
}

export default App
