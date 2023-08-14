<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>Meine Dateien</h1>
    </div>

    <div class="section__container-status grid place-items-center" v-if="!fetched">
      <Loading />
    </div>

    <div class="section__container-status" v-else-if="userFiles.length == 0">
      <p>Du teilst aktuell keine Dateien mit imgrio. :[</p>
    </div>

    <div v-else>
      <div class="section__container-subtitle">
        <p>Du teilst aktuell {{ userFiles?.length }} Dateien mit imgrio</p>
      </div>
      <div class="section__container-list">
        <FileCard :userFile="file" v-for="file in userFiles" :key="file.id" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref, reactive, onMounted } from 'vue';
import { useUserFilesStore } from '@/stores/userFiles';

import Loading from '../../components/Loading.vue';
import FileCard from '../../components/FileCard.vue';
import type { UserFile } from '@/models';

const userFilesStore = useUserFilesStore();
const userFilesData = reactive<{ userFiles: UserFile[] }>({ userFiles: [] });

const fetched = ref(false);

onMounted(async () => {
  await userFilesStore.fetchUserFiles();
  userFilesData.userFiles = userFilesStore.userFiles as UserFile[];

  var fetchedAmount = 0;

  userFilesData.userFiles.forEach((userFile) => {
    const image = new Image();
    image.onload = function () {
      fetchedAmount++;
      if (fetchedAmount == userFiles.value.length) {
        setTimeout(() => {
          fetched.value = true;
        }, 1250);
      }
    };
    image.src = userFile.url;
  });
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
