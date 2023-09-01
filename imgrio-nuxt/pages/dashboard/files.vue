<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>{{ $t('pages.dashboard.files.title') }}</h1>

      <div class="section__title-menu">
        <p
          class="text-red-500 font-bold"
          @click="async () => await deleteSelectedAsync()"
          v-if="selectedUserFiles.length > 0"
        >
          {{ $t('pages.dashboard.files.delete') }}
        </p>
        <p @click="selectionMode = true" v-if="!selectionMode">
          {{ $t('pages.dashboard.files.select') }}
        </p>
        <p
          @click="
            selectionMode = false;
            selectedUserFiles.length = 0;
          "
          v-else
        >
          {{ $t('pages.dashboard.files.cancel') }}
        </p>
      </div>
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
          <ImageCard
            :userFile="userFile"
            @click="handleClick($event, userFile)"
            class="section__container-list-card"
            :class="{
              selected: selectedUserFiles.includes(userFile)
            }"
            v-if="userFile.type.startsWith('image/')"
          />
          <FileCard
            :userFile="userFile"
            @click="handleClick($event, userFile)"
            class="section__container-list-card"
            :class="{
              selected: selectedUserFiles.includes(userFile)
            }"
            v-else
          />
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, computed, ref } from 'vue';
import { useToast } from 'vue-toastification';
import { useUserFilesStore } from '~/stores/userFiles';
import { UserFile } from '~/models';

import Loading from '~/components/Loading.vue';
import FileCard from '~/components/FileCard.vue';
import ImageCard from '~/components/ImageCard.vue';

const i18n = useI18n();
const toast = useToast();
const userFilesStore = useUserFilesStore();

const selectionMode = ref<boolean>(false);
const selectedUserFiles = ref<UserFile[]>([]);

onMounted(async () => {
  await userFilesStore.fetchDataAsync();
});

const userFiles = computed(() => userFilesStore.userFiles);

function handleClick(event: Event, userFile: UserFile) {
  if (!selectionMode.value) {
    return;
  }

  event.preventDefault();

  if (!selectedUserFiles.value.includes(userFile)) {
    selectedUserFiles.value.push(userFile);
  } else {
    const index = selectedUserFiles.value.findIndex(
      (selectedUserFile) => selectedUserFile == userFile
    );
    selectedUserFiles.value.splice(index, 1);
  }
}

async function deleteSelectedAsync() {
  const deletePromises = selectedUserFiles.value.map((selectedUserFile) => {
    return userFilesStore.deleteUserFileAsync(selectedUserFile.id);
  });
  await Promise.all(deletePromises);

  toast.success(`${selectedUserFiles.value.length} ${i18n.t('toasts.successDeleted')}`);

  selectedUserFiles.value.length = 0;
  selectionMode.value = false;
}
</script>

<style scoped>
.section__container {
  color: #fff;
}

.section__title {
  display: flex;
  justify-content: space-between;
}

.section__title-menu {
  display: flex;
  gap: 20px;
  font-weight: 400;
  font-size: 1rem;
}

.section__title-menu p {
  cursor: pointer;
}

.section__container-list {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 12px;
}

.section__container-list-card.selected {
  transform: scale(1);
  filter: brightness(0.3) saturate(0);
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
