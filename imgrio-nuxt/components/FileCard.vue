<template>
  <a :href="`/v/${userFile.id}`">
    <div
      class="card"
      :class="{ jump: animationPlaying }"
      @mouseenter="playAnimation()"
    >
      <div class="card__container">
        <img class="card__container-image" :src="userFile.url" loading="lazy" />
        <div class="card__container-info">
          <div class="card__container-info-title">
            <p>
              {{
                userFile.title.length > 17
                  ? userFile.title.substring(0, 15).concat("...")
                  : userFile.title
              }}
            </p>
          </div>
          <div class="card__container-info-icon">
            <button
              @click.prevent="
                copyToClipboard(`https://imgrio.com/v/${userFile.id}`)
              "
            >
              <svg class="icon" viewBox="0 0 512 512" fill="#fff">
                <path
                  d="M326.612 185.391c59.747 59.809 58.927 155.698.36 214.59-.11.12-.24.25-.36.37l-67.2 67.2c-59.27 59.27-155.699 59.262-214.96 0-59.27-59.26-59.27-155.7 0-214.96l37.106-37.106c9.84-9.84 26.786-3.3 27.294 10.606.648 17.722 3.826 35.527 9.69 52.721 1.986 5.822.567 12.262-3.783 16.612l-13.087 13.087c-28.026 28.026-28.905 73.66-1.155 101.96 28.024 28.579 74.086 28.749 102.325.51l67.2-67.19c28.191-28.191 28.073-73.757 0-101.83-3.701-3.694-7.429-6.564-10.341-8.569a16.037 16.037 0 0 1-6.947-12.606c-.396-10.567 3.348-21.456 11.698-29.806l21.054-21.055c5.521-5.521 14.182-6.199 20.584-1.731a152.482 152.482 0 0 1 20.522 17.197zM467.547 44.449c-59.261-59.262-155.69-59.27-214.96 0l-67.2 67.2c-.12.12-.25.25-.36.37-58.566 58.892-59.387 154.781.36 214.59a152.454 152.454 0 0 0 20.521 17.196c6.402 4.468 15.064 3.789 20.584-1.731l21.054-21.055c8.35-8.35 12.094-19.239 11.698-29.806a16.037 16.037 0 0 0-6.947-12.606c-2.912-2.005-6.64-4.875-10.341-8.569-28.073-28.073-28.191-73.639 0-101.83l67.2-67.19c28.239-28.239 74.3-28.069 102.325.51 27.75 28.3 26.872 73.934-1.155 101.96l-13.087 13.087c-4.35 4.35-5.769 10.79-3.783 16.612 5.864 17.194 9.042 34.999 9.69 52.721.509 13.906 17.454 20.446 27.294 10.606l37.106-37.106c59.271-59.259 59.271-155.699.001-214.959z"
                />
              </svg>
            </button>
          </div>
        </div>
      </div>
    </div>
  </a>
</template>

<script setup lang="ts">
import { ref } from "vue";
// import { useToast } from 'vue-toastification';

// const toast = useToast();

const animationPlaying = ref(false);

const props = defineProps({
  userFile: {
    type: Object,
    required: true,
  },
});

function playAnimation() {
  animationPlaying.value = true;
  setTimeout(() => {
    animationPlaying.value = false;
  }, 300);
}

function copyToClipboard(text: string) {
  navigator.clipboard.writeText(text);
  // toast.success('Link in Zwischenablage kopiert.')
}
</script>

<style scoped>
.card {
  width: 100%;
  aspect-ratio: 1/0.75;
  position: relative;
  border-radius: 1rem;
  color: var(--color-lightest);
  background-color: var(--color-light);
  box-shadow: inset 0 0 0 2px var(--color-secondary2);
  overflow: hidden;
  cursor: pointer;
}

.card__container {
  position: relative;
  height: 100%;
}

.card__container-image {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.card__container-info {
  position: absolute;
  width: 100%;
  bottom: 0;
  padding: 1.5rem 1rem 0.25rem 1rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background: linear-gradient(
    to top,
    rgba(0, 0, 0, 0.6) 30%,
    rgba(0, 0, 0, 0) 100%
  );
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
  transform: translateX(-50%);
  transition: all 0.1s ease-in-out;
}

.card:hover .card__container-info-icon {
  opacity: 1;
  transform: translateX(0);
}

.icon {
  height: 15px;
}

.jump {
  animation: jump 0.3s;
}

@keyframes jump {
  50% {
    transform: translateY(-2%);
  }
}
</style>
