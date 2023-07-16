<script setup lang="ts">
import { RouterView } from 'vue-router';

import NavBar from '../components/NavBar.vue';
import SubNavBar from '../components/SubNavBar.vue';
</script>

<template>
  <NavBar style="background: var(--color-darkest); height: 4rem" />
  <SubNavBar />

  <RouterView />
</template>
