<script setup lang="ts">
import {UserContent} from "@/models";
import {AspectRatio} from '@/components/ui/aspect-ratio'

const props = defineProps({
  userContent: {
    type: Object as () => UserContent,
    required: true
  }
});
</script>

<template>
  <div class="rounded-lg overflow-hidden ease-in-out transition-colors border border-zinc-400 border-opacity-0 lg:group-hover:bg-zinc-900 lg:group-hover:border-opacity-20">
    <a :href="`/v/${userContent.id}`">
      <AspectRatio class="bg-zinc-300" :ratio="1/0.75">
<!--        <NuxtImg class="object-cover w-full h-full" :src="userContent.url" :alt="userContent.title" loading="lazy" placeholder />-->
        <span class="block object-cover w-full h-full" :style="`background-image: url(${userContent.url}); background-size: cover; background-position: center;`"></span>
      </AspectRatio>
      <div class="px-4 py-3">
        <p class="text-lg font-semibold truncate">{{ userContent.title }}</p>
        <p class="text-zinc-400">{{ new Date(userContent.dateOfCreation).toLocaleDateString('en-us', { weekday:"long", year:"numeric", month:"short", day:"numeric"}) }}</p>
      </div>
    </a>
  </div>
</template>