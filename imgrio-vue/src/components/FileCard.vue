<template>
  <a :href="`/v/${file.id}`">
    <div class="card" :class="{ jump: animationPlaying }" @mouseenter="playAnimation()">
      <div class="card__container">
        <div class="card__container-image" :style="`background-image: url(${file.url})`"></div>
        <div class="card__container-info">
          <div class="card__container-info-title">
            <p>
              {{ file.title.length > 17 ? file.title.substring(0, 15).concat('...') : file.title }}
            </p>
          </div>
          <div class="card__container-info-icon">
            <svg viewBox="0 0 28 25" class="icon" fill="#fff">
              <path
                d="M13.145 2.13l1.94-1.867 12.178 12-12.178 12-1.94-1.867 8.931-8.8H.737V10.93h21.339z"
              ></path>
            </svg>
          </div>
        </div>
      </div>
    </div>
  </a>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const animationPlaying = ref(false);

const props = defineProps({
  file: {
    type: Object,
    required: true
  }
});

function playAnimation() {
  animationPlaying.value = true;
  setTimeout(() => {
    animationPlaying.value = false;
  }, 300);
}
</script>

<style scoped>
.card {
  width: 100%;
  aspect-ratio: 1/0.75;
  position: relative;
  border-radius: 1rem;
  background-color: var(--color-light);
  box-shadow: inset 0 0 0 2px var(--color-secondary2);
  overflow: hidden;
  cursor: pointer;
}

.card:hover .card__container-info-icon {
  opacity: 1;
  transform: translateX(20%);
}

.card__container {
  position: relative;
  height: 100%;
}

.card__container-image {
  min-height: 100%;
  min-width: 100%;
  background-size: cover;
  background-position: center;
}

.card__container-info {
  position: absolute;
  width: 100%;
  bottom: 0;
  padding: 1.5rem 1rem 0.25rem 1rem;
  display: flex;
  align-items: flex-end;
  justify-content: space-between;
  background: linear-gradient(to top, rgba(0, 0, 0, 0.6) 30%, rgba(0, 0, 0, 0) 100%);
}

.card__container-info-title {
  font-family: var(--font-family);
  font-size: 1rem;
  font-weight: 400;
  line-height: 30px;
  white-space: nowrap;
}

.card__container-info-icon {
  opacity: 0;
  transform: translateX(-20%);
  transition: all 0.2s ease-in-out;
}

.icon {
  width: 1rem;
  height: 1rem;
}

.jump {
  animation: jump 0.3s;
}

@keyframes jump {
  0% {
    transform: scale(1);
  }
  50% {
    transform: translateY(-0.25rem);
  }
  100% {
    transform: scale(1);
  }
}
</style>
