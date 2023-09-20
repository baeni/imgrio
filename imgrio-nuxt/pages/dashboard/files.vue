<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Label } from "@/components/ui/label";
import { Button } from "@/components/ui/button";

import UserContentCard from "@/components/UserContentCard.vue";

const userContentsStore = useUserContentsStore();

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
});

const userContents = computed(() => userContentsStore.userContents);
</script>

<template>
  <section class="container pt-28">
    <p class="flex justify-between mb-9">
      <span class="text-2xl font-bold">My Files</span>
      <Dialog>
        <DialogTrigger>
          <Button variant="ghost" size="sm">
            Upload File
          </Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Upload File</DialogTitle>
            <DialogDescription>
              Files with up to 10 MB allowed.
            </DialogDescription>
          </DialogHeader>
          <div class="p-10 rounded-lg transition-colors border border-dashed border-zinc-400 border-opacity-20 lg:hover:border-opacity-100">
            <input class="hidden" id="file" type="file" accept="" />
            <Label class="text-center select-none cursor-pointer" for="file">Drag'n'Drop file here<br>or select</Label>
          </div>
          <DialogFooter>
            <Button type="submit">
              Upload
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </p>
    
    <ul class="grid gap-x-4 gap-y-8 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4" v-if="userContents">
      <UserContentCard v-for="userContent in userContents" :key="userContent.id" :userContent="userContent" />
    </ul>
  </section>
</template>