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
  'Loading... und dabei wird der rote Teppich für dich ausgerollt.'
];

function getRandomLoadingMessage() {
  return loadingMessages[Math.floor(Math.random() * loadingMessages.length)];
}
</script>

<template>
  <div>
    <div
      class="w-0 h-0 float-left triangle border-x-[10px] border-x-transparent border-b-[17.32px] border-b-white"
    ></div>
    <div
      class="w-0 h-0 float-left triangle border-x-[10px] border-x-transparent border-t-[17.32px] border-t-white"
    ></div>
    <div
      class="w-0 h-0 float-left triangle border-y-[10px] border-y-transparent border-l-[17.32px] border-l-white"
    ></div>
  </div>
  <!--  <p>{{ getRandomLoadingMessage() }}</p>-->
</template>

<style scoped>
.triangle {
  transform: scale(0);
  animation: fx 1.5s ease infinite;
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
