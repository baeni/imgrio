<script setup lang="ts">
import { ref } from 'vue';
import { apiClient } from '@/axios.conf';
import { UserContent } from '@/models';
import { Skeleton } from '@/components/ui/skeleton';
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger
} from '@/components/ui/alert-dialog';

const userContent = ref<UserContent>((await apiClient.get(`files/${useRoute().params.id}`)).data);

useServerSeoMeta({
  ogSiteName: 'imgrio',
  twitterSite: 'imgrio',

  ogTitle: userContent.value?.title,
  twitterTitle: userContent.value?.title,

  ogImage: userContent.value?.url,
  twitterImage: userContent.value?.url,

  twitterCard: 'summary_large_image'
});
</script>

<template>
  <span
      class="absolute top-0 left-0 w-screen h-screen bg-no-repeat bg-cover bg-center -z-10" :style="`background-image: url(${userContent.url}); filter: blur(150px);`"
  ></span>
  <section class="flex h-screen w-screen items-center justify-center">
    <div class="absolute">
      <NuxtImg
          class="max-w-full max-h-[70vh] mx-auto rounded-xl"
          :src="userContent.url"
          :alt="userContent.title"
          quality="50"
          placeholder
          v-if="userContent"
      />
      <Skeleton class="h-[50vh] aspect-video rounded-xl" v-else />

      <div class="mt-4">
        <div class="w-fit mx-auto">
          <div v-if="userContent">
            <p
                class="text-md font-semibold px-6 py-4 truncate bg-zinc-950 bg-opacity-20 backdrop-blur-md border border-zinc-400 border-opacity-20 rounded-2xl md:text-xl"
            >
              {{ userContent.title }}
            </p>

            <AlertDialog>
              <AlertDialogTrigger class="w-full opacity-40">
                <p class="drop-shadow-md">Show details</p>
              </AlertDialogTrigger>
              <AlertDialogContent>
                <AlertDialogHeader>
                  <AlertDialogTitle>Details for "{{ userContent.title }}"</AlertDialogTitle>
                  <AlertDialogDescription>
                    <ul>
                      <li>Shared by Unknown</li>
                      <li>
                        Uploaded on
                        {{
                          new Date(userContent.dateOfCreation).toLocaleDateString('en-us', {
                            weekday: 'long',
                            year: 'numeric',
                            month: 'short',
                            day: 'numeric'
                          })
                        }}
                      </li>
                    </ul>
                  </AlertDialogDescription>
                </AlertDialogHeader>
                <AlertDialogFooter>
                  <AlertDialogCancel>Cancel</AlertDialogCancel>
                  <AlertDialogAction>Report content</AlertDialogAction>
                </AlertDialogFooter>
              </AlertDialogContent>
            </AlertDialog>
          </div>
          <Skeleton class="w-80 h-16 rounded-2xl" v-else />
        </div>
      </div>
    </div>
  </section>
</template>
