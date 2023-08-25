<template>
  <div class="overlay" id="overlay">
    <div class="section__container" @click.stop>
      <div class="section__title">
        <h1>{{ $t("components.modals.uploadModal.title") }}</h1>
      </div>

      <form class="section__container-form">
        <label class="section__container-form-drop-area" for="input">
          <div class="section__container-form-drop-area-icon">
            <img src="../../assets/icons/image.svg" />
          </div>

          <div class="section__container-form-drop-area-title">
            <p>{{ $t("components.modals.uploadModal.description") }}</p>
          </div>

          <div
            class="section__container-form-drop-area-file"
            v-if="selectedFile"
          >
            <p>{{ selectedFile.name }}</p>
          </div>

          <input
            type="file"
            accept="image/*"
            id="input"
            name="file"
            @change="handleFileChange"
            required
            hidden
          />
        </label>
        <Knob
          text="Gib mir einen Link!"
          :primary="!!selectedFile"
          @click="postFileAsync"
        />
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { apiClient } from "@/axios.conf";
import { useUserFilesStore } from "@/stores/userFiles";
// import { useToast } from 'vue-toastification';

import Knob from "../inputs/Knob.vue";

// const toast = useToast()
const selectedFile = ref<File | null>();
const userFilesStore = useUserFilesStore();

const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files.length > 0) {
    selectedFile.value = input.files[0];
  }
};

async function postFileAsync() {
  try {
    if (!selectedFile.value) {
      // toast.error('Du musst eine Datei auswählen!')
      return;
    }

    const currentUser = useCurrentUser();

    const formData = new FormData();
    formData.append("file", selectedFile.value);
    const response = (
      await apiClient.post(`files/users/${currentUser.value?.uid}`, formData)
    ).data;

    closeModal();
    copyToClipboard(response.url);
    // toast.success('Link in Zwischenablage kopiert.')

    userFilesStore.userFiles?.unshift(response.userFile);
    selectedFile.value = null;
  } catch {
    // toast.error('Ein Fehler ist aufgetreten, versuche es erneut.')
    return;
  }
}

function closeModal() {
  document.getElementById("overlay")?.click();
}

function copyToClipboard(url: string) {
  navigator.clipboard.writeText(url);
}
</script>

<style scoped>
.overlay {
  display: flex;
  position: fixed;
  width: 100%;
  height: 100%;
  left: 0;
  top: 0;
  justify-content: center;
  align-items: center;
  overflow: hidden;
  backdrop-filter: brightness(0.25) blur(10px);
  z-index: 999;
}

.section__container {
  margin: 0 auto;
  padding: 1.5rem;
  padding-top: 3rem;
  width: 400px;
  background: var(--color-darker);
  border-radius: 10px;
  color: #fff;
  text-align: center;
}

.section__container-subtitle {
  color: var(--color-title);
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 25px;
}

.section__container-form-drop-area {
  display: flex;
  align-items: center;
  gap: 35px;
  padding: 1.5rem;
  position: relative;
  margin-bottom: 1rem;
  border: 2px dashed var(--color-dark);
  border-radius: 10px;
  cursor: pointer;
  transition: border 0.1s ease-in-out;
}

.section__container-form-drop-area:hover {
  border: 2px dashed var(--color-primary);
}

.section__container-form-drop-area-icon img {
  height: 2rem;
}

.section__container-form-drop-area-title {
  color: var(--color-light);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 20px;
  text-align: left;
}

.section__container-form-drop-area-file {
  display: flex;
  justify-content: center;
  align-items: center;
  position: absolute;
  top: 0.25rem;
  left: 0.25rem;
  width: calc(100% - 0.5rem);
  height: calc(100% - 0.5rem);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 25px;
  background: var(--color-dark);
  border-radius: 5px;
  color: var(--color-lightest);
}
</style>