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
  <li>
    <a :href="`/v/${userContent.id}`">
      <AspectRatio class="bg-zinc-300 rounded-2xl overflow-hidden" :ratio="1/0.75">
        <img class="relative object-cover w-full h-full" :src="userContent.url" :alt="userContent.title" loading="lazy" />
        <div class="flex absolute bottom-0 w-full justify-between items-center">
          <p class="text-sm font-semibold px-3 py-2 m-2 truncate bg-zinc-950 bg-opacity-20 backdrop-blur-md border border-zinc-50 border-opacity-20 rounded-xl">{{ userContent.title }}</p>
          <FaIcon class="m-4" :icon="['fas', 'paperclip']" />
        </div>
      </AspectRatio>
    </a>
  </li>
</template>