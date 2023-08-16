<template>
  <div class="cluster">
    <RouterLink to="./favorites">
      <div class="cluster__card">
        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512" fill="#fff">
          <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
          <path
            d="M47.6 300.4L228.3 469.1c7.5 7 17.4 10.9 27.7 10.9s20.2-3.9 27.7-10.9L464.4 300.4c30.4-28.3 47.6-68 47.6-109.5v-5.8c0-69.9-50.5-129.5-119.4-141C347 36.5 300.6 51.4 268 84L256 96 244 84c-32.6-32.6-79-47.5-124.6-39.9C50.5 55.6 0 115.2 0 185.1v5.8c0 41.5 17.2 81.2 47.6 109.5z"
          />
        </svg>
      </div>
    </RouterLink>
    <RouterLink to="./favorites">
      <div class="cluster__card">
        <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 512 512" fill="#fff">
          <!--! Font Awesome Free 6.4.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
          <path
            d="M75 75L41 41C25.9 25.9 0 36.6 0 57.9V168c0 13.3 10.7 24 24 24H134.1c21.4 0 32.1-25.9 17-41l-30.8-30.8C155 85.5 203 64 256 64c106 0 192 86 192 192s-86 192-192 192c-40.8 0-78.6-12.7-109.7-34.4c-14.5-10.1-34.4-6.6-44.6 7.9s-6.6 34.4 7.9 44.6C151.2 495 201.7 512 256 512c141.4 0 256-114.6 256-256S397.4 0 256 0C185.3 0 121.3 28.7 75 75zm181 53c-13.3 0-24 10.7-24 24V256c0 6.4 2.5 12.5 7 17l72 72c9.4 9.4 24.6 9.4 33.9 0s9.4-24.6 0-33.9l-65-65V152c0-13.3-10.7-24-24-24z"
          />
        </svg>
      </div>
    </RouterLink>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useToast } from 'vue-toastification';

const toast = useToast();

const animationPlaying = ref(false);

function playAnimation() {
  animationPlaying.value = true;
  setTimeout(() => {
    animationPlaying.value = false;
  }, 300);
}

function copyToClipboard(text: string) {
  navigator.clipboard.writeText(text);
  toast.success('Link in Zwischenablage kopiert.');
}
</script>

<style scoped>
.cluster {
  width: 100%;
  display: grid;
  grid-template-rows: 1fr 1fr;
  gap: 12px;
  aspect-ratio: 1/0.75;
  color: var(--color-lightest);
  box-shadow: inset 0 0 0 2px var(--color-secondary2);
}

.cluster__card {
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 1rem;
  background-color: var(--color-dark);
  font-size: 1.5rem;
  transition: all 0.5s cubic-bezier(0.29, 1.01, 1, -0.68);
}

.cluster__card:hover {
  transform: translateY(-5px);
}

.cluster__card svg {
  margin: 0 auto;
}
</style>
