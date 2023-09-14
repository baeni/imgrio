<script setup lang="ts">
import {Button} from "@/components/ui/button";

const props = defineProps({
  transparent: {
    type: Boolean,
    default: false
  }
});

const config = useRuntimeConfig();
const user = useSupabaseUser();
</script>

<template>
  <nav class="flex fixed justify-center w-full h-20 z-10 bg-opacity-50" :class="`${transparent ? 'bg-transparent backdrop-blur-0' : 'bg-zinc-950 backdrop-blur-2xl'}`">
    <div class="flex container justify-between items-center">
      <NuxtLink to="/">
        <img class="w-14" src="/logo192.png" alt="imgrio" />
      </NuxtLink>

      <div class="grid grid-cols-3">
        <NuxtLink to="/">
          <Button class="w-full" variant="ghost">Home</Button>
        </NuxtLink>
        <NuxtLink to="/sharex">
          <Button class="w-full" variant="ghost">ShareX</Button>
        </NuxtLink>
        <NuxtLink to="/dashboard/files">
          <Button class="w-full" variant="ghost">Dashboard</Button>
        </NuxtLink>
      </div>

      <NuxtLink :to="config.public.logoutPath!" v-if="user">
        <Button class="w-full" variant="outline">Log Out</Button>
      </NuxtLink>
      <NuxtLink :to="config.public.loginPath!" v-else>
        <Button class="w-full" variant="outline">Log In</Button>
      </NuxtLink>
    </div>
  </nav>
</template>