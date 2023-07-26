<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>Meine Dateien</h1>
    </div>

    <div v-if="userFiles.length != 0 && fetched">
      <div class="section__container-subtitle">
        <p>Du teilst aktuell {{ userFiles?.length }} Dateien mit Imgrio</p>
      </div>
      <div class="section__container-list">
        <FileCard :file="file" v-for="file in userFiles" :key="file.id" />
      </div>
    </div>

    <div class="section__container-status" v-if="userFiles.length == 0 && !fetched">
      <p>Wir entstauben gerade all deine Dateien. Einen Moment noch!</p>
    </div>

    <div class="section__container-status" v-if="userFiles.length == 0 && fetched">
      <p>Du teilst aktuell keine Dateien mit imgrio. :[</p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, reactive, onMounted } from 'vue';
import { useUserFilesStore } from '@/stores/userFiles';

import FileCard from '../../components/FileCard.vue';
import type { UserFile } from '@/models';

const userFilesStore = useUserFilesStore();
const userFilesData = reactive<{ userFiles: UserFile[] }>({ userFiles: [] });

let fetched = false;

onMounted(async () => {
  await userFilesStore.fetchUserFiles();
  userFilesData.userFiles = userFilesStore.userFiles as UserFile[];

  fetched = true;
});

const userFiles = computed(() => userFilesData.userFiles);
</script>

<style scoped>
.section__container {
  color: #fff;
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

.section__container-status {
  font-family: var(--font-family);
  font-size: 1.1rem;
  line-height: 25px;
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
