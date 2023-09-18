<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';

import UserContentCard from "@/components/UserContentCard.vue";

const userContentsStore = useUserContentsStore();

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
});

const userContents = computed(() => userContentsStore.userContents);
</script>

<template>
  <section class="container pt-24">
    <p class="text-2xl font-bold mb-9">My Files</p>
    
    <ul class="grid gap-x-4 gap-y-8 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4" v-if="userContents">
      <UserContentCard v-for="userContent in userContents" :key="userContent.id" :userContent="userContent" />
    </ul>
  </section>
</template>