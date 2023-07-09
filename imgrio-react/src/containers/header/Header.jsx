import React, { useState, useEffect } from 'react';
import './header.css';

import { FaClone } from 'react-icons/fa';

const Header = () => {
  // const [data, setData] = useState(null);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const response = await fetch(process.env.REACT_APP_API_URL + '/files');
  //       const jsonData = await response.json();
  //       setData(jsonData);
  //     } catch (error) {
  //       console.error('An error occurred while attempting to fetch data:', error);
  //     }
  //   };

  //   fetchData();
  // }, []);

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
          {/* <p><span className="header__container-statistics--bold">{data?.count ?? '?'}</span> Dateien sind aktuell dank imgrio im Umlauf!</p> */}
        </div>
      </div>
    </div>
  )
}

export default Header
