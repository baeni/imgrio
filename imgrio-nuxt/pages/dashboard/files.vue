<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';
import Loading from '@/components/Loading.vue';
import UserContentGrid from '@/components/UserContentGrid.vue';

const fetched = ref<boolean>(false);
const userContentsStore = useUserContentsStore();
const userContents = computed(() => userContentsStore.userContents);

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
  fetched.value = true;
});
</script>

<template>
  <section class="container pt-28">
    <p class="text-2xl font-bold">My Files</p>

    <Loading class="flex w-full justify-center mt-4" v-if="!fetched" />
    <UserContentGrid :userContents="userContents" v-else-if="userContents.length > 0" />
    <div class="mt-4" v-else>
      <p class="text-xl text-zinc-500 font-bold">It seems you did not upload any content — yet</p>
    </div>
  </section>
</template>
