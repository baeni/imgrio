<script setup lang="ts">
import { ref } from 'vue';

import UploadPopup from '../components/UploadPopup.vue';

let isUploadPopupVisible = ref(false);

function toggleUploadPopup() {
  isUploadPopupVisible.value = !isUploadPopupVisible.value;
}
</script>

<template>
  <div class="subnavbar section--padding">
    <div class="subnavbar__links">
      <div class="subnavbar__links-container">
        <p><a href="/dashboard/files">Meine Dateien</a></p>
        <!-- <p><a href="/dashboard/upload">Datei Hochladen</a></p> -->
        <p><a @click="toggleUploadPopup">Datei Hochladen</a></p>
      </div>
    </div>
  </div>

  <div class="overlay" @click="toggleUploadPopup" v-if="isUploadPopupVisible">
    <UploadPopup />
  </div>
</template>

<style scoped>
.subnavbar {
  padding-block: 0;
  display: flex;
  position: fixed;
  top: 4rem;
  height: 2.25rem;
  width: 100%;
  justify-content: space-between;
  align-items: center;
  background: rgba(255, 255, 255, 0.1);
  backdrop-filter: blur(10px);
  border-top: 2px solid var(--color-dark);
  z-index: 999;
}

.subnavbar__links {
  display: flex;
  flex: 1;
  justify-content: flex-start;
  align-items: center;
}

.subnavbar__links-container {
  display: flex;
  flex: 1;
  align-items: center;
}

.subnavbar__links-container p,
.subnavbar__sign p,
.subnavbar__menu-container {
  color: #fff;
  font-family: var(--font-family);
  font-weight: 500;
  font-size: 0.8rem;
  line-height: 20px;
  text-transform: Upp;

  margin-inline-end: 2rem;
  cursor: pointer;
}

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
  backdrop-filter: blur(5px);
  z-index: 999;
}
</style>
