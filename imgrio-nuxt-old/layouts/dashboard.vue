<template>
  <div>
    <NavBar style="height: 4rem" />
    <SubNavBar />

    <slot />
  </div>
</template>

<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
import SubNavBar from '../components/SubNavBar.vue';
</script>
