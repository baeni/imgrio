import React from 'react';
import './sharex.css';

const ShareX = () => {
  return (
    <div className="sharex">
      <div className="sharex__container">
        <div className="sharex__container-headline">
          <h2 id="sharex">ShareX</h2>
        </div>
        <div className="sharex__container-text">
          <p>ShareX ist eine beliebte Open-Source Screenshot Verwaltungs Software für Microsoft Windows. Hier erfährst du, wie du ShareX mit imgrio konfigurierst.</p>

          <h3>Installation</h3>
          <p>Zu Beginn solltest du erst einmal ShareX installieren. Klicke dafür hier und anschließend auf "Download", um die aktuellste Version herunterzuladen. Beim Setup kannst du einfach immer auf "Weiter" klicken, bis die Installation von ShareX abgeschlossen ist.</p>
        
          <h3>Konfiguration</h3>
          <p>Als nächstes konfigurieren wir alles so, dass ShareX mit imgrio funktioniert. Da wir das meiste bereits für dich erledigt haben, musst du dafür nur unsere Konfiguration herunterladen. Nun importierst du diese Konfiguration mit einem Doppelklick auf die heruntergeladene Datei in ShareX. Das einzige, was du jetzt noch selber erledigen musst, ist das einfügen deiner Zugangsdaten. Navigiere dafür zur folgenden Einstellung:</p>
        
          <p>In der Liste auf der linken Seite solltest du nun eine Konfiguration namens "imgrio" sehen. Stelle sicher, dass diese ausgewählt ist. Anschließend findest du auf der rechten Seite eine Tabelle mit den Einträgen "Email" und "Password". In den jeweils dazugehörigen Werte-feldern solltest du nun deine Zugangsdaten eintragen.</p>
        </div>
      </div>
    </div>
  )
}

export default ShareX
