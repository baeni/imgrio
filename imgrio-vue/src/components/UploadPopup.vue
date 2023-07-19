<script setup lang="ts">
import { ref } from 'vue';
import { apiClient } from '@/axios';
import { useToast } from 'vue-toastification';

import Knob from './Knob.vue';

const toast = useToast();
const selectedFile = ref<File | null>(null);

const handleFileChange = (event: Event) => {
  const target = event.target as HTMLInputElement;
  if (target.files && target.files.length > 0) {
    selectedFile.value = target.files[0];
  }
};

const postFile = async () => {
  try {
    if (!selectedFile.value) {
      toast.error('Du musst eine Datei auswählen!', {
        timeout: 2000
      });
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile.value);

    toast.info('Datei wird hochgeladen...');

    await apiClient.post('files/users/6822c35d-4884-44f3-b3d6-ea172c0c2265', formData);

    toast.success('Datei erfolgreich hochgeladen.');
  } catch (error) {
    toast.error('Ein Fehler ist aufgetreten, versuche es erneut.');
    return;
  }
};
</script>

<template>
  <div class="section__container">
    <div class="section__container-title section__title">
      <h1>Datei Hochladen</h1>
    </div>
    <form class="section__container-form">
      <label class="section__container-form-drop-area" for="input">
        <div class="section__container-form-drop-area-icon">
          <img src="../assets/icons/image.svg" />
        </div>
        <div class="section__container-form-drop-area-title">
          <p>
            Datei hierher ziehen <br />
            oder auswählen
          </p>
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
      <Knob text="Hochladen" primary @click="postFile" />
    </form>
  </div>
</template>

<style scoped>
.section__container {
  margin: 0 auto;
  padding: 1.5rem;
  padding-top: 3rem;
  width: 20%;
  min-width: 350px;
  background: var(--color-dark);
  border-radius: 10px;
  color: #fff;
  text-align: center;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 55px;
}

.section__container-subtitle {
  color: var(--color-title);
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 25px;
}

.section__container-form-drop-area {
  display: block;
  padding-block: 2rem;
  margin-bottom: 1rem;
  border: 2px dashed var(--color-darkest);
  border-radius: 10px;
  cursor: pointer;
  transition: border 0.1s ease-in-out;
}

.section__container-form-drop-area:hover {
  border: 2px dashed var(--color-primary);
}

.section__container-form-drop-area-icon img {
  width: 3rem;
  padding-bottom: 2rem;
}

.section__container-form-drop-area-title {
  color: var(--color-light);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 25px;
}
</style>
