<script setup lang="ts">
import { onMounted } from "vue";
import { signOutUser } from "@/composables/useSupabase";

onMounted(() => {
  setTimeout(async () => {
    await signOutUser();
    navigateTo("/");
  }, 2000)
});
</script>

<template>
  <section class="flex h-screen max-w-3xl mx-auto">
    <div class="m-auto text-center">
      <p class="text-7xl font-bold mb-5">Bye Bye!</p>
      <p class="text-xl">You will be redirected in a moment</p>
    </div>
  </section>
</template>
