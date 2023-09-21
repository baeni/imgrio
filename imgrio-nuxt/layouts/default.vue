<script setup lang="ts">
import Navbar from '@/components/Navbar.vue'
</script>

<template>
  <Navbar transparent />
  
  <main>
    <slot />
  </main>
</template>