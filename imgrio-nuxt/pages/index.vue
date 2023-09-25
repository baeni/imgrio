<script setup lang="ts">
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

const user = useSupabaseUser();
</script>

<template>
  <span
    class="absolute top-0 left-0 w-screen h-screen -z-10 bg-gradient-to-br from-zinc-950 to-blue-950"
  ></span>
  <section class="flex h-screen max-w-3xl mx-auto">
    <div class="my-auto">
      <p class="text-6xl font-bold">Take. Give. <span class="text-blue-400">Share.</span></p>
      <p class="text-lg my-9">
        imgrio is a file sharing platform. Currently, full access is only available to selected
        people. If you still wish to use imgrio, feel free to request your personal access now!
      </p>

      <div class="grid grid-cols-5 gap-4 w-fit" v-if="!user">
        <Input class="col-span-2" placeholder="someone@imgrio.com" />
        <Button class="col-span-1" size="sm">Request Access</Button>
      </div>

      <div class="flex gap-2" v-if="user">
        <NuxtLink to="/sharex">
          <Button variant="outline" size="lg">Get started</Button>
        </NuxtLink>
        <NuxtLink to="/dashboard/files">
          <Button variant="secondary" size="lg">Dashboard</Button>
        </NuxtLink>
      </div>
    </div>
  </section>
</template>
