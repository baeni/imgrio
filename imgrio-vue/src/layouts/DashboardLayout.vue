<template>
  <NavBar style="background: var(--color-darkest); height: 4rem" />
  <SubNavBar />

  <router-view v-slot="{ Component, route }">
    <transition
      enter-from-class="opacity-0"
      enter-to-class="opacity-100"
      enter-active-class="transition-opacity duration-500"
      leave-from-class="opacity-100"
      leave-to-class="opacity-0"
      leave-active-class="transition-opacity duration-500"
    >
      <component :is="Component" :key="route.path" />
    </transition>
  </router-view>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';

import NavBar from '../components/NavBar.vue';
import SubNavBar from '../components/SubNavBar.vue';
</script>
