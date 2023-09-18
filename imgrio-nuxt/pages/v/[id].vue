<script setup lang="ts">
import {ref} from 'vue';
import {apiClient} from '@/axios.conf'
import {UserContent} from "@/models";
import {Skeleton} from "@/components/ui/skeleton";
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger,
} from '@/components/ui/alert-dialog';

onMounted(async () => {
  userContent.value = (await apiClient.get(`files/${useRoute().params.id}`)).data;
})

const userContent = ref<UserContent|null>(null);
</script>

<template>
  <section class="flex h-screen container items-center justify-center">
    <span class="absolute w-full h-full -z-10 bg-no-repeat bg-cover bg-center" :style="`background-image: url(${userContent.url}); filter: blur(150px);`" v-if="userContent" />

    <div>
      <NuxtImg class="max-w-full max-h-[70vh] rounded-xl" :src="userContent.url" :alt="userContent.title" placeholder v-if="userContent" />
      <Skeleton class="h-[50vh] aspect-video rounded-xl" v-else />
      
      <div class="mt-4">
        <div class="w-fit mx-auto">
          <div v-if="userContent">
            <p class="text-2xl font-semibold px-6 py-4 truncate bg-zinc-950 bg-opacity-20 backdrop-blur-md border border-zinc-50 border-opacity-20 rounded-2xl">{{ userContent.title }}</p>

            <AlertDialog>
              <AlertDialogTrigger class="float-right mr-2 opacity-40">
                <p class="shadow-md">Show details</p>
              </AlertDialogTrigger>
              <AlertDialogContent>
                <AlertDialogHeader>
                  <AlertDialogTitle>Details for "{{ userContent.title }}"</AlertDialogTitle>
                  <AlertDialogDescription>
                    <ul>
                      <li>Shared by Unknown</li>
                      <li>Uploaded on {{ new Date(userContent.dateOfCreation).toLocaleDateString('en-us', { weekday:"long", year:"numeric", month:"short", day:"numeric"}) }}</li>
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