<template>
  <div>
    <div class="triangle triangle-up"></div>
    <div class="triangle triangle-down"></div>
    <div class="triangle triangle-right"></div>
  </div>
  <!-- <p>{{ getRandomLoadingMessage() }}</p> -->
</template>

<script setup lang="ts">
const loadingMessages = [
  'Die Hamster drehen noch ein paar Runden im Rad...',
  'Wir zählen die Pixel... eins, zwei, viele!',
  'Bald fertig, nur noch ein Kaffee für den Server!',
  'Lade Magie... Bitte warten, während wir Feenstaub sammeln.',
  'Die Einhörner malen gerade die letzten Pixel bunt an.',
  'Hast du schon gehört? Loading ist das neue Schwarz.',
  'Wartet darauf, dass die Schwerkraft wieder funktioniert...',
  'Noch schneller als ein Faultier im Marathon!',
  'Loading... und dabei wird fleißig Schokolade in Energie umgewandelt.',
  'Wir jonglieren mit Nullen und Einsen... fast geschafft!',
  'Einhornverkehrsregelung wird optimiert...',
  'Bald fertig, wir überzeugen die Hamster, schneller zu rennen.',
  'Loading... weil selbst Server eine Kaffeepause brauchen.',
  'Wir zaubern gerade am Internet der Dinge... bitte warten Sie auf Ihr Ding.',
  'Die Roboterarme sortieren gerade die Bits und Bytes in Ordnung.',
  'Geduld ist eine Tugend, die wir gerade codieren.',
  'Während du wartest, empfehlen wir dir, ein Witz zu erzählen.',
  'Die Aliens übertragen gerade die Daten in Lichtgeschwindigkeit.',
  'Noch schnell die Virtual-Reality-Brillen putzen...',
  'Loading... und dabei wird der rote Teppich für dich ausgerollt.',
]

function getRandomLoadingMessage() {
  return loadingMessages[Math.floor(Math.random() * loadingMessages.length)]
}
</script>

<style scoped>
.triangle {
  width: 0;
  height: 0;
  float: left;
  transform: scale(0);
  animation: fx 1.5s ease infinite;
}

.triangle-up {
  border-left: 10px solid transparent;
  border-right: 10px solid transparent;
  border-bottom: 17.32px solid white;
}

.triangle-down {
  border-left: 10px solid transparent;
  border-right: 10px solid transparent;
  border-top: 17.32px solid white;
}

.triangle-right {
  border-top: 10px solid transparent;
  border-bottom: 10px solid transparent;
  border-left: 17.32px solid white;
}

.triangle:nth-child(1) {
  animation-delay: 0.25s;
}

.triangle:nth-child(2) {
  animation-delay: 0.75s;
}

.triangle:nth-child(3) {
  animation-delay: 1.25s;
}

@keyframes fx {
  12.5% {
    transform: scale(1);
    opacity: 1;
  }
  100% {
    opacity: 0;
  }
}

p {
  padding-top: 1.5rem;
  color: var(--color-light);
}
</style>
