<template>
  <NuxtPage v-if="$route.path.startsWith('/auth/')" />

  <NuxtLayout name="default" v-else>
    <NuxtPage />
  </NuxtLayout>
</template>