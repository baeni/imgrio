<script setup lang="ts">
import { onMounted, computed, ref } from 'vue';
import { useUserContentsStore } from '~/stores/userContents';
import { UserContent } from '~/models'
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
const selectedFile = ref<File | null>(null);

const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files.length > 0) {
    selectedFile.value = input.files[0];
  }
};

async function handlePostAsync() {
  try {
    if (!selectedFile.value) {
      console.log("No file selected.");
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile.value);
    const response = await userContentsStore.postUserContentAsync(formData);

    // copyToClipboard(response.url);
    console.log("Link copied to clipboard.");
    selectedFile.value = null;
  } catch {
    console.log("An error has occured.");
    return;
  }
}
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
          <div class="rounded-lg transition-colors border-2 border-dashed border-zinc-400 border-opacity-50 lg:hover:border-opacity-100">
            <input class="hidden" id="file" type="file" accept="" @change="handleFileChange" />
            <Label class="p-10 text-center select-none cursor-pointer" for="file">Drag'n'Drop file here<br>or select</Label>
          </div>
          <DialogFooter>
            <Button @click="async () => await handlePostAsync()">
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