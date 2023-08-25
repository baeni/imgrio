<template>
  <NuxtLayout name="dashboard" v-if="$route.path.startsWith('/dashboard/')">
    <NuxtPage />
  </NuxtLayout>

  <NuxtLayout name="default" v-else>
    <NuxtPage />
  </NuxtLayout>
</template>
