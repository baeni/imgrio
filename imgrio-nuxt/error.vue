<script setup>
import {Button} from "~/components/ui/button";
</script>

<template>
  <span
      class="absolute top-0 left-0 w-screen h-screen bg-no-repeat bg-cover bg-center -z-10" :style="`background-image: url('');`"
  ></span>
  <section class="flex h-screen max-w-3xl mx-auto">
    <div class="my-auto">
      <p class="text-6xl font-bold">Whoops!</p>
      <p class="text-lg my-9">
        We tried our best but it seems you've taken a wrong turn anywhere. May we guide you back?
      </p>

      <div class="flex gap-2">
        <NuxtLink to="/">
          <Button variant="" size="lg">Back Home</Button>
        </NuxtLink>
      </div>
    </div>
  </section>
</template>