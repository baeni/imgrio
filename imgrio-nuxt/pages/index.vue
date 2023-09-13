<script setup lang="ts">
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
</script>

<template>
  <section class="flex h-screen max-w-3xl mx-auto">
    <div class="m-auto text-center">
      <p class="text-6xl font-bold">Take. Give. <span class="text-blue-400">Share.</span></p>
      <p class="text-lg my-9">
        imgrio is a file sharing platform. Currently, full access is only available to selected people.<br/>
        If you still wish to use imgrio, feel free to request your personal access now!
      </p>

      <div class="grid grid-cols-3 gap-2 w-fit mx-auto">
        <Input class="col-span-2" placeholder="someone@imgrio.com" />
        <Button class="col-span-1">Request Access</Button>
      </div>
      
      <p class="my-6 opacity-40 italic">Already have access?</p>
      
      <div class="grid grid-cols-2 gap-2 w-fit mx-auto">
        <NuxtLink to="/sharex">
          <Button class="w-full" variant="outline">Get started</Button>
        </NuxtLink>
        <NuxtLink to="/auth/login">
          <Button class="w-full" variant="secondary">Log In</Button>
        </NuxtLink>
      </div>
    </div>
  </section>
</template>