<script setup lang="ts">
import {Button} from "@/components/ui/button";

const user = useSupabaseUser();
</script>

<template>
  <nav class="flex fixed justify-center w-full h-20 z-10 bg-zinc-950 bg-opacity-50 backdrop-blur-2xl">
    <div class="flex container justify-between items-center">
      <img class="w-14" src="/logo192.png" />

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

      <NuxtLink to="/auth/logout" v-if="user">
        <Button class="w-full" variant="outline">Log Out</Button>
      </NuxtLink>
      <NuxtLink to="/auth/login" v-else>
        <Button class="w-full" variant="outline">Log In</Button>
      </NuxtLink>
    </div>
  </nav>
</template>