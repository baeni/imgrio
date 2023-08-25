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
              <FaIcon :icon="['fas', 'paperclip']" />
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
