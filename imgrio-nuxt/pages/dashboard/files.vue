<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';
import UserContentGrid from "~/components/UserContentGrid.vue";

const userContentsStore = useUserContentsStore();

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
});

const userContents = computed(() => userContentsStore.userContents);
</script>

<template>
  <section class="container pt-28">
    <p class="text-2xl font-bold">My Files</p>
    
    <UserContentGrid :userContents="userContents" v-if="userContents" />
  </section>
</template>