import React from 'react';
import './header.css';

import { FaClone } from 'react-icons/fa';

import statistics from '../../assets/statistics.png';

const Header = () => {
  return (
    <div className="header">
      <div className="header__container">
        <div className="header__container-slogan">
          <p>Take. Give. <span className="header__container-slogan--accent">Share.</span></p>
        </div>
        <div className="header__container-description">
          <p>imgrio ist eine Plattform zum Teilen von Dateien. Aktuell ist der vollumfängliche Zugriff nur für ausgewählte Personen möglich.</p>
        </div>
        <div className="header__container-buttons">
          <button className="btn btn--primary">Anmelden</button>
          <button className="btn btn--secondary">Los gehts!</button>
        </div>
        <div className="header__container-statistics">
          <FaClone className="header__container-statistics-icon" />
          <p><span className="header__container-statistics--bold">1.248</span> Inhalte wurden bereits mit imgrio geteilt!</p>
        </div>
      </div>
    </div>
  )
}

export default Header
