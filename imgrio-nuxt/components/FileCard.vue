<template>
  <a :href="`/f/${userFile.id}`">
    <div class="card">
      <div class="card__container">
        <div class="card__container-type">
          <p>
            {{ userFile.type.split('/')[1].toUpperCase() }}
          </p>
        </div>
        <div class="card__container-info">
          <div class="card__container-info-title">
            <p>
              {{
                userFile.title.length > 25
                    ? userFile.title.substring(0, 23).concat('...')
                    : userFile.title
              }}
            </p>
          </div>
          <div class="card__container-info-icon">
            <button @click.prevent="copyToClipboard(`https://imgrio.com/v/${userFile.id}`)">
              <FaIcon :icon="['fas', 'paperclip']" />
            </button>
          </div>
        </div>
      </div>
    </div>
  </a>
</template>

<script setup lang="ts">
// import { ref } from "vue";
import { computed } from 'vue';
import { useToast } from 'vue-toastification';
import { UserFile } from '~/models';

const i18n = useI18n();
const toast = useToast();

// const animationPlaying = ref(false);

const props = defineProps({
  userFile: {
    type: Object as () => UserFile,
    required: true
  }
});

// function playAnimation() {
//   animationPlaying.value = true;
//   setTimeout(() => {
//     animationPlaying.value = false;
//   }, 300);
// }

function copyToClipboard(text: string) {
  navigator.clipboard.writeText(text);
  toast.success(i18n.t('toasts.successLinkCopied'));
}
</script>

<style scoped>
.card {
  width: 100%;
  aspect-ratio: 1/0.75;
  position: relative;
  border-radius: 1rem;
  color: var(--color-lightest);
  background-color: var(--color-dark);
  overflow: hidden;
  cursor: pointer;
}

.card__container {
  position: relative;
  height: 100%;
}

.card__container-type {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  font-size: 2.5rem;
  font-weight: bold;
  color: var(--color-darkest);
}

.card__container-info {
  position: absolute;
  width: 100%;
  bottom: 0;
  padding: 1.5rem 1rem 0.25rem 1rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
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

/* .jump {
  animation: jump 0.3s;
}

@keyframes jump {
  50% {
    transform: translateY(-2%);
  }
} */
</style>
