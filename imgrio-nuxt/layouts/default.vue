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
  <Navbar :transparent="$route.path.startsWith('/v/') || $route.path == '/'" />
  <main>
    <slot />
  </main>
</template>