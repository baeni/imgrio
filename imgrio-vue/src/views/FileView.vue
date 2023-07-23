<script setup lang="ts">
import { useRoute } from 'vue-router';
import { onMounted, ref } from 'vue';
import { apiClient } from '@/axios';

const file = ref();

onMounted(async () => {
  file.value = (await apiClient.get(`files/${useRoute().params.id}`)).data;
});
</script>

<template>
  <div class="section gradient__bg">
    <div class="section__container section--padding" v-if="file">
      <div class="section__container-image">
        <img :src="file.url" />
      </div>
      <div class="section__container-title">
        <p>{{ file.title }}</p>
      </div>
      <div class="section__container-date">
        {{
          new Date(file.uploadedAt).toLocaleDateString('de-de', {
            day: '2-digit',
            month: 'long',
            year: 'numeric'
          })
        }}
      </div>
    </div>
  </div>
</template>

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

.section__container-image img {
  max-width: 100%;
  max-height: 83vh;
  margin-bottom: 2rem;
  background-color: var(--color-secondary2);
  background-repeat: no-repeat;
  background-size: cover;
  transform-style: preserve-3d;
  animation: pulse 5s infinite ease;
  border-radius: 1rem;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 1.5rem;
  font-weight: 400;
  line-height: 35px;
  white-space: nowrap;
}

.section__container-date {
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
