<template>
  <div class="section" v-if="userFile">
    <img class="section-background" :src="userFile.url" />
    <div class="section__container section--padding">
      <div class="section__container-image">
        <img :src="userFile.url" />
      </div>
      <div class="section__container-title">
        <p>{{ userFile.title }}</p>
      </div>
      <div class="section__container-subtitle">
        <p class="section__container-subtitle-author">
          {{ $t('pages.view.unknown') }}
        </p>
        <p class="section__container-subtitle-date">
          {{
            new Date(userFile.dateOfCreation).toLocaleDateString(i18n.locale.value, {
              day: '2-digit',
              month: 'long',
              year: 'numeric'
            })
          }}
        </p>
        <a @click.prevent="deleteFileAsync">{{ $t('pages.view.delete') }}</a>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useToast } from 'vue-toastification';
import { UserFile } from '~/models';
import { useUserFilesStore } from '~/stores/userFiles';
import { apiClient } from '~/axios.conf';

const i18n = useI18n();
const router = useRouter();
const toast = useToast();

const userFile = ref<UserFile>((await apiClient.get(`files/${useRoute().params.id}`)).data);
const userFilesStore = useUserFilesStore();

useServerSeoMeta({
  ogSiteName: 'imgrio',
  twitterSite: 'imgrio',

  ogTitle: userFile.value?.title,
  twitterTitle: userFile.value?.title,

  ogImage: userFile.value?.url,
  twitterImage: userFile.value?.url,

  twitterCard: 'summary_large_image'
});

async function deleteFileAsync() {
  try {
    await userFilesStore.deleteUserFileAsync(userFile.value!.id);

    await router.push('/dashboard/files');
  } catch {
    toast.error(i18n.t('toasts.errorRetry'));
    return;
  }
}
</script>

<style scoped>
.section {
  min-height: 100vh;
  position: relative;
}

.section-background {
  position: absolute;
  object-fit: cover;
  height: 100%;
  filter: blur(200px);
  z-index: -1;
}

.section__container {
  color: #fff;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;
  margin: 0 auto;
  vertical-align: middle;
}

.section__container-image {
  margin-bottom: 2.5rem;
}

.section__container-image img {
  max-width: 100%;
  max-height: 65vh;
  background-color: var(--color-light);
  background-repeat: no-repeat;
  background-size: cover;
  transform-style: preserve-3d;
  animation: pulse 5s infinite ease;
  border-radius: 1rem;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 2.5rem;
  font-weight: 700;
  line-height: 40px;
  white-space: nowrap;
  margin-bottom: 0.5rem;
}

.section__container-subtitle {
  display: inline-flex;
  margin: 1rem auto 0;
  gap: 50px;
  padding: 1rem 2rem;
  border-radius: 1rem;
  background: rgba(36, 37, 41, 0.5);
  border: 1px solid rgba(194, 198, 203, 0.175);
  backdrop-filter: blur(20px);
}

.section__container-subtitle-author {
  font-family: var(--font-family);
  font-size: 1rem;
}

.section__container-subtitle-date {
  font-family: var(--font-family);
  font-size: 1rem;
}

/* @keyframes pulse {
  0% {
    transform: rotateZ(-0.5deg) translateY(0px);
  }

  50% {
    transform: rotateZ(0.5deg) translateY(-10px);
  }

  100% {
    transform: rotateZ(-0.5deg) translateY(0px);
  }
} */
</style>
