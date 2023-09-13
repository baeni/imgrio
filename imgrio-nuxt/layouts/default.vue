<script setup lang="ts">
import Navbar from '@/components/Navbar.vue'

const props = defineProps({
  extended: {
    type: Boolean,
    default: false
  }
});
</script>

<template>
  <Navbar />
  <main>
    <slot />
  </main>
</template>