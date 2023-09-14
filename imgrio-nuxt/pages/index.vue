<script setup lang="ts">
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'

const config = useRuntimeConfig();
const user = useSupabaseUser();
</script>

<template>
  <section class="flex h-screen max-w-3xl mx-auto">
<!--    <img class="col-span-1 my-auto scale-150 -translate-x-16" src="/illustrations/index&#45;&#45;restricted-access.png" alt="illustration" />-->
    <div class="my-auto">
      <p class="text-6xl font-bold">Take. Give. <span class="text-blue-400">Share.</span></p>
      <p class="text-lg my-9">
        imgrio is a file sharing platform. Currently, full access is only available to selected people. If you still wish to use imgrio, feel free to request your personal access now!
      </p>

      <div class="grid grid-cols-3 gap-2 w-fit" v-if="!user">
        <Input class="col-span-2" placeholder="someone@imgrio.com" />
        <Button class="col-span-1">Request Access</Button>
      </div>
      
      <NuxtLink class="text-sm mt-2 opacity-30" :href="config.public.LoginPath!" v-if="!user"><Button variant="link">I already have access!</Button></NuxtLink>

      <div class="grid grid-cols-2 gap-2 w-fit" v-if="user">
        <NuxtLink to="/sharex">
          <Button class="w-full" variant="outline">Get started</Button>
        </NuxtLink>
        <NuxtLink to="/dashboard/files">
          <Button class="w-full" variant="secondary">Dashboard</Button>
        </NuxtLink>
      </div>
      
    </div>
  </section>
</template>