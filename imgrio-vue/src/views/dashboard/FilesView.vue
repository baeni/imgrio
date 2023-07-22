<script setup lang="ts">
import { computed } from 'vue';
import { useUserFilesStore } from '@/stores/userFiles';

import FileCard from '../../components/FileCard.vue';

const userFilesStore = useUserFilesStore();
userFilesStore.fetchUserFiles();
const userFiles = computed(() => userFilesStore.userFiles);
</script>

<template>
  <div class="section__container section--margin">
    <div class="section__container-title section__title">
      <h1>Meine Dateien</h1>
    </div>
    <div>
      <div class="section__container-subtitle">
        <p>Oktober 2023</p>
      </div>
      <div class="section__container-list">
        <FileCard :file="file" v-for="file in userFiles.value" />
      </div>
    </div>
  </div>
</template>

<style scoped>
.section__container {
  color: #fff;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 55px;
}

.section__container-subtitle {
  padding-bottom: 1rem;
  color: var(--color-title);
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 25px;
}

.section__container-list {
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  gap: 12px;
}

@media screen and (max-width: 1600px) {
  .section__container-list {
    grid-template-columns: repeat(4, 1fr);
  }
}

@media screen and (max-width: 962px) {
  .section__container-list {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media screen and (max-width: 768px) {
  .section__container-list {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media screen and (max-width: 414px) {
  .section__container-list {
    grid-template-columns: repeat(1, 1fr);
  }
}
</style>
@/stores/userFiles
