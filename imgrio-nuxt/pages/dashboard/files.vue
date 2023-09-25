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

    <UserContentGrid :userContents="userContents" v-if="userContents.length > 0" />
    <Loading class="flex w-full justify-center mt-4" v-else-if="!fetched" />
    <div class="mt-4" v-else>
      <p class="text-xl text-zinc-500 font-bold">It seems you did not upload any content — yet</p>
    </div>
  </section>
</template>
