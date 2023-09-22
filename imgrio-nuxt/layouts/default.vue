<script setup lang="ts">
import Navbar from '@/components/Navbar.vue'
</script>

<template>
  <Navbar :transparent="!$route.path.startsWith('/dashboard/')" />
  
  <main>
    <slot />
  </main>
</template>