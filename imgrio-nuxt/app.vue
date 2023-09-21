<script setup lang="ts">

</script>

<template>
  <NuxtPage v-if="$route.path.startsWith('/auth/')" />

  <NuxtLayout name="dashboard" v-else-if="$route.path.startsWith('/dashboard/')">
    <NuxtPage />
  </NuxtLayout>
  
  <NuxtLayout name="default" v-else>
    <NuxtPage />
  </NuxtLayout>
</template>