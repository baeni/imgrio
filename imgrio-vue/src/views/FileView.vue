<template>
  <div class="section gradient__bg" v-if="userFile">
    <div class="section__container section--padding">
      <div class="section__container-image">
        <img :src="userFile.url" />
      </div>
      <div class="section__container-title">
        <p>{{ userFile.title }}</p>
      </div>
      <div class="section__container-subtitle">
        <p class="section__container-subtitle-author">baeni</p>
        <p class="section__container-subtitle-date">
          {{
            new Date(userFile.dateOfCreation).toLocaleDateString('de-de', {
              day: '2-digit',
              month: 'long',
              year: 'numeric'
            })
          }}
        </p>
        <p @click="deleteFileAsync">Löschen</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useRoute } from 'vue-router';
import { onMounted, ref } from 'vue';
import { useHead } from '@vueuse/head';
import { apiClient } from '@/axios';
import { useUserDetailsStore } from '@/stores/userDetails';
import type { UserDetails, UserFile } from '@/models';
import { useToast } from 'vue-toastification';
import router from '@/router';

useHead({
  meta: [
    {
      name: 'og:image',
      content:
        'https://images.unsplash.com/photo-1691893310317-c2c0769f7b3f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=464&q=80'
    },
    {
      name: 'twitter:image',
      content:
        'https://images.unsplash.com/photo-1691893310317-c2c0769f7b3f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=464&q=80'
    }
  ]
});

const userDetailsStore = useUserDetailsStore();

const userDetails = ref<UserDetails>();
const userFile = ref<UserFile>();

const toast = useToast();

onMounted(async () => {
  userDetails.value = userDetailsStore.userDetails;
  userFile.value = (await apiClient.get(`files/${useRoute().params.id}`)).data;
});

async function deleteFileAsync() {
  try {
    const response = (await apiClient.delete(`files/${userFile.value?.id}`)).data;

    router.back();
  } catch {
    toast.error('Ein Fehler ist aufgetreten, versuche es erneut.');
    return;
  }
}
</script>

<style scoped>
.section {
  min-height: 100vh;
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
  margin-bottom: 2rem;
  margin: 0 auto;
  background-color: var(--color-secondary2);
  background-repeat: no-repeat;
  background-size: cover;
  transform-style: preserve-3d;
  animation: pulse 5s infinite ease;
  border-radius: 1rem;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 2rem;
  font-weight: 700;
  line-height: 40px;
  white-space: nowrap;
  margin-bottom: 0.5rem;
}

.section__container-subtitle {
  display: flex;
  justify-content: center;
  gap: 25px;
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
