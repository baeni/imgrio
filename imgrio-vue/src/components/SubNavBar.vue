<template>
  <div class="subnavbar section--padding">
    <div class="subnavbar__links">
      <div class="subnavbar__links-container">
        <RouterLink to="./files">Meine Dateien</RouterLink>
        <a href="javascript:;" @click="showModal = true">Datei Hochladen</a>
        <RouterLink to="./settings">Einstellungen</RouterLink>
      </div>
    </div>
  </div>

  <UploadPopup v-show="showModal" @click="showModal = false" />
</template>

<script setup lang="ts">
import { ref } from 'vue';

import UploadPopup from '../components/modals/UploadModal.vue';

let showModal = ref(false);
</script>

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
  z-index: 998;
}

.subnavbar__links {
  display: flex;
  flex: 1;
  justify-content: flex-start;
  align-items: center;
  white-space: nowrap;
}

.router-link-active {
  font-weight: 900;
  color: #fff;
}

.subnavbar__links-container {
  display: flex;
  flex: 1;
  align-items: center;
}

.subnavbar__links-container a,
.subnavbar__sign p,
.subnavbar__menu-container {
  color: var(--color-light);
  font-family: var(--font-family);
  font-weight: 500;
  font-size: 0.8rem;
  line-height: 20px;

  margin-inline-end: 2rem;
  cursor: pointer;
}

.router-link-active {
  color: #fff !important;
}
</style>
