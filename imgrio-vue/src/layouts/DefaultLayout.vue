<template>
  <NavBar />

  <router-view v-slot="{ Component, route }">
    <transition>
      <component :is="Component" :key="route.path" />
    </transition>
  </router-view>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';

import NavBar from '../components/NavBar.vue';
</script>

<style scoped>
.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>
