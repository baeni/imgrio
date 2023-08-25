<template>
  <NuxtLayout name="dashboard" v-if="$route.path.startsWith('/dashboard/')">
    <NuxtPage />
  </NuxtLayout>

  <NuxtLayout name="default" v-else>
    <NuxtPage />
  </NuxtLayout>
</template>

<style scoped>
    .page-enter-active,
    .page-leave-active {
        transition: all 0.4s;
    }

    .page-enter-from,
    .page-leave-to {
        opacity: 0;
        filter: blur(1rem);
    }
</style>