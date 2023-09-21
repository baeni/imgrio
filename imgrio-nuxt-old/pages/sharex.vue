<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>ShareX</h1>
    </div>

    <div class="mb-7">
      <p>
        imgrio ist eine Plattform zum Teilen von Dateien. Aktuell ist der vollumfängliche Zugriff
        nur für ausgewählte Personen möglich.
      </p>
    </div>

    <div class="mb-7">
      <h2 id="installation" class="text-lg font-bold">Installation</h2>
      <p>
        Zu Beginn solltest du erst einmal ShareX installieren. Klicke dafür
        <a href="https://getsharex.com/" target="_blank">hier</a>
        und anschließend auf "Download", um die aktuellste Version herunterzuladen.
        <br />
        Beim Setup kannst du einfach immer auf "Weiter" klicken, bis die Installation von ShareX
        abgeschlossen ist.
      </p>
    </div>

    <div class="mb-7">
      <h2 id="configuration" class="text-lg font-bold">Konfiguration</h2>
      <p>
        Als nächstes konfigurieren wir alles so, dass ShareX mit imgrio funktioniert. Da wir das
        meiste bereits für dich erledigt haben, musst du dafür nur unsere
        <a href="" download>Konfiguration herunterladen</a>.
        <br />
        Nun importierst du diese Konfiguration mit einem Doppelklick auf die heruntergeladene Datei
        in ShareX. Das einzige, was du jetzt noch selber erledigen musst, ist das einfügen deiner
        Zugangsdaten. Navigiere dafür zur folgenden Einstellung:
      </p>

      <Textfield
        class="my-7"
        value="Ziele > Benutzerdefinierte Uploader-Einstellungen..."
        disabled
      />

      <p>
        In der Liste auf der linken Seite solltest du nun eine Konfiguration namens "imgrio" sehen.
        Stelle sicher, dass diese ausgewählt ist. Anschließend findest du auf der rechten Seite eine
        Tabelle mit dem Eintrag "AccessToken". In dem dazugehörigen Werte-feld solltest du nun
        deinen zuvor generierten Acces-Token eintragen.
      </p>
    </div>
  </div>
</template>

<script setup lang="ts">
import Textfield from '@/components/inputs/Textfield.vue';
</script>

<style scoped>
.section__container {
  color: #fff;
  font-family: var(--font-family);
}

.section__container h2 {
  font-weight: 500;
  font-size: 1rem;
  line-height: 30px;
  color: var(--color-light);
}

a {
  font-weight: 500;
  color: var(--color-primary);
}

a:hover {
  text-decoration: underline;
}

input {
  width: 100%;
}
</style>
