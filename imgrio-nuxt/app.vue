<script setup lang="ts">
</script>

<template>
  <NuxtPage v-if="$route.path.startsWith('/auth')" />

  <NuxtLayout name="default" extended v-else>
    <NuxtPage />
  </NuxtLayout>
</template>