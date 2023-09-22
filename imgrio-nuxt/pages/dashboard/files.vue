<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';
import UserContentGrid from '~/components/UserContentGrid.vue';

const userContentsStore = useUserContentsStore();
const userContents = computed(() => userContentsStore.userContents);

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
});
</script>

<template>
  <section class="container pt-28">
    <p class="text-2xl font-bold">My Files</p>

    <UserContentGrid :userContents="userContents" v-if="userContents.length > 0" />
  </section>
</template>
