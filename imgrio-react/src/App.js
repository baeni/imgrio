import React from 'react';

import './App.css';

import { Navbar } from './components';
import { Header, ShareX } from './containers';

import { pca } from './authConfig';
import { MsalProvider, AuthenticatedTemplate } from '@azure/msal-react';

const App = () => {
  return (
    <MsalProvider instance={pca}>
      <div className="App">
        <div className="gradient__bg">
            <Navbar />
            <Header />
        </div>
        <AuthenticatedTemplate>
          <ShareX />
        </AuthenticatedTemplate>
      </div>
    </MsalProvider>
  )
}

export default App
