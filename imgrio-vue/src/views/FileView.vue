<script setup lang="ts">
import { useRoute } from 'vue-router';

const fetchData = async () => {
  try {
    const response = await fetch(`"http://localhost:8080/files/${useRoute().params.id}"`);
    return await response.json();
  } catch (error) {
    console.error('An error occurred while attempting to fetch data:', error);
  }
};

const file = await fetchData();
</script>

<template>
  <div class="section gradient__bg">
    <div class="secion__container section__padding">
      <div
        class="section__container-image"
        :style="`'background-image: url('http://49.12.218.142/~root/imgrio/UploadedFiles/${file.uploadedBy}/${file.nameWithExtension}');'`"
      ></div>
    </div>
  </div>
</template>

<style scoped>
.secion__container {
  color: #fff;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;
  margin: 0 auto;
  vertical-align: middle;
  min-height: 100vh;
}

.section__container-image {
  position: relative;
  height: 80vh;
  max-width: 100%;
  background-color: var(--color-secondary2);
  background-repeat: no-repeat;
  background-size: cover;
  transform-style: preserve-3d;
  animation: rot 5s infinite ease;
  border-radius: 1rem;
}

@keyframes rot {
  0% {
    transform: rotateZ(-0.5deg) translateY(0px);
  }

  50% {
    transform: rotateZ(0.5deg) translateY(-10px);
  }

  100% {
    transform: rotateZ(-0.5deg) translateY(0px);
  }
}
</style>
