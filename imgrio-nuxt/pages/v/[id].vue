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
        <p class="section__container-subtitle-author">Unbekannt</p>
        <p class="section__container-subtitle-date">
          {{
            new Date(userFile.dateOfCreation).toLocaleDateString("de-de", {
              day: "2-digit",
              month: "long",
              year: "numeric",
            })
          }}
        </p>
        <a href="javascript:;" @click="deleteFileAsync">Löschen</a>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { apiClient } from "@/axios.conf";
import type { UserFile } from "@/models";
import { useToast } from "vue-toastification";

useHead({
  meta: [
    {
      name: "og:image",
      content: "https://images.unsplash.com/photo-1691893310317-c2c0769f7b3f",
    },
    {
      name: "twitter:image",
      content: "https://images.unsplash.com/photo-1691893310317-c2c0769f7b3f",
    },
  ],
});

const router = useRouter();
const toast = useToast();

const userFile = ref<UserFile>();

onMounted(async () => {
  userFile.value = (await apiClient.get(`files/${useRoute().params.id}`)).data;
});

async function deleteFileAsync() {
  try {
    const response = (await apiClient.delete(`files/${userFile.value?.id}`))
      .data;

    router.back();
  } catch {
    toast.error("Ein Fehler ist aufgetreten, versuche es erneut.");
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
