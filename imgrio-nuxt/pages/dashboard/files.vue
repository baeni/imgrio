<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>{{ $t('pages.dashboard.files.title') }}</h1>
    </div>

    <div class="section__container-status grid place-items-center" v-if="!userFiles">
      <Loading />
    </div>

    <div class="section__container-status" v-else-if="userFiles.length == 0">
      <p>{{ $t('pages.dashboard.files.notSharing') }}</p>
    </div>

    <div v-else>
      <ul class="section__container-list">
        <li v-for="userFile in userFiles" :key="userFile.id">
          <ImageCard :userFile="userFile" v-if="userFile.type.startsWith('image/')" />
          <FileCard :userFile="userFile" v-else />
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserFilesStore } from '~/stores/userFiles';

import Loading from '~/components/Loading.vue';
import FileCard from '~/components/FileCard.vue';
import ImageCard from "~/components/modals/ImageCard.vue";

const userFilesStore = useUserFilesStore();

onMounted(async () => {
  await userFilesStore.fetchDataAsync();
});

const userFiles = computed(() => userFilesStore.userFiles);
</script>

<style scoped>
.section__container {
  color: #fff;
}

.section__container-list {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 12px;
}

.section__container-status {
  font-family: var(--font-family);
  font-size: 1.1rem;
  line-height: 25px;
}

@media screen and (max-width: 1920px) {
  .section__container-list {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media screen and (max-width: 962px) {
  .section__container-list {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media screen and (max-width: 768px) {
  .section__container-list {
    grid-template-columns: repeat(1, 1fr);
  }
}
</style>
