import React from 'react';

import './App.css';

import { Navbar } from './components';
import { Header, ShareX } from './containers';

const App = () => {
  return (
    <div className="App">
        <div className="gradient__bg">
            <Navbar />
            <Header />
        </div>
        <ShareX />
    </div>
  )
}

export default App
