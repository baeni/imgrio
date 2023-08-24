<template>
  <NuxtLayout name="dashboard" v-if="$route.path.startsWith('/dashboard/')">
    <NuxtPage />
  </NuxtLayout>

  <NuxtLayout name="default" v-else>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
import "@/assets/main.css";
</script>
