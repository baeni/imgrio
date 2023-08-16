<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>Meine Dateien</h1>
      <Knob text="Favoriten" href="./favorites" small />
    </div>

    <div class="section__container-status grid place-items-center" v-if="!fetched">
      <Loading />
    </div>

    <div class="section__container-status" v-else-if="userFiles.length == 0">
      <p>Du teilst aktuell keine Dateien mit imgrio. :[</p>
    </div>

    <div v-else>
      <div class="section__container-list">
        <FileCard :userFile="file" v-for="file in userFiles" :key="file.id" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref, reactive, onMounted } from 'vue';
import { useUserFilesStore } from '@/stores/userFiles';

import Knob from '@/components/inputs/Knob.vue';
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
        fetched.value = true;
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

.section__title {
  display: flex;
  justify-content: space-between;
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
