<template>
  <div class="section--center" v-if="userFile">
    <img class="section-background" :src="userFile.url" v-if="isImage" />
    <div class="section__container section--padding">
      <div class="section__container-image" v-if="isImage">
        <img :src="userFile.url" />
      </div>
      <div class="section__container-title">
        <p>{{ userFile.title }}</p>
      </div>
      <div class="section__container-subtitle">
        <p class="section__container-subtitle-size">{{ sizeInMb }} MB</p>
        <p class="section__container-subtitle-date">
          {{
            new Date(userFile.dateOfCreation).toLocaleDateString(i18n.locale.value, {
              day: '2-digit',
              month: 'long',
              year: 'numeric'
            })
          }}
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { UserFile } from '~/models';
import { apiClient } from '~/axios.conf';

const i18n = useI18n();
const router = useRouter();

const userFile = ref<UserFile>((await apiClient.get(`files/${useRoute().params.id}`)).data);

const isImage = computed(() => userFile.value.type.startsWith('image/'));
const sizeInMb = computed(() => (userFile.value.size / (1024 * 1024)).toFixed(2));

useServerSeoMeta({
  ogSiteName: 'imgrio',
  twitterSite: 'imgrio',

  ogTitle: userFile.value?.title,
  twitterTitle: userFile.value?.title,

  ogImage: userFile.value?.url,
  twitterImage: userFile.value?.url,

  twitterCard: 'summary_large_image'
});
</script>

<style scoped>
.section--center {
  min-height: 100vh;
  position: relative;
  overflow: hidden;
}

.section-background {
  position: absolute;
  object-fit: cover;
  min-width: 100%;
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
  margin: 0 auto;
  background-color: var(--color-light);
  border-radius: 1rem;
  overflow: hidden;
  animation: pulse 5s infinite ease;
}

.section__container-image img {
  max-width: 100%;
  max-height: 65vh;
}

.section__container-title {
  margin-top: 2.5rem;
  font-family: var(--font-family);
  font-size: 2.5rem;
  font-weight: 700;
  white-space: nowrap;
}

.section__container-subtitle {
  display: inline-flex;
  margin: 1rem auto 0;
  gap: 50px;
  padding: 1rem 2rem;
  border-radius: 1rem;
  background: rgba(36, 37, 41, 0.3);
  border: 1px solid rgba(194, 198, 203, 0.175);
  backdrop-filter: blur(20px);
  align-items: center;
}

.section__container-subtitle-size,
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
