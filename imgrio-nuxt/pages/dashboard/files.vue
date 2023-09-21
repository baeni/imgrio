<script setup lang="ts">
import { onMounted, computed, ref } from 'vue';
import { UserContent } from "~/models";
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
import { Toggle } from "@/components/ui/toggle";
import UserContentCard from "@/components/UserContentCard.vue";

const userContentsStore = useUserContentsStore();

onMounted(async () => {
  await userContentsStore.fetchDataAsync();
});

const userContents = computed(() => userContentsStore.userContents);

const selectionMode = ref<boolean>(false);
const selectedUserContents = ref<UserContent[]>([]);

const formFile = ref<File | null>(null);

function toggleSelectionMode() {
  selectedUserContents.value.length = 0;
  selectionMode.value = !selectionMode.value
}

function handleUserContentSelection(event: Event, userContent: UserContent) {
  if (!selectionMode.value) {
    return;
  }
  
  event.preventDefault();
  
  if (!selectedUserContents.value.includes(userContent)) {
    selectedUserContents.value.push(userContent);
  }
  else {
    const index = selectedUserContents.value.findIndex(
        (x) => x == userContent
    );
    selectedUserContents.value.splice(index, 1);
  }
}

const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files.length > 0) {
    formFile.value = input.files[0];
  }
};

async function handleDeleteAsync() {
  try {
    const deletePromises = selectedUserContents.value.map((selectedUserContent) => {
      return userContentsStore.deleteUserContentAsync(selectedUserContent.id);
    });
    const response = await Promise.all(deletePromises);
    
    toggleSelectionMode();
  } catch {
    console.log("An error has occured.");
    return;
  }
}

async function handlePostAsync() {
  try {
    if (formFile.value == null) {
      console.log("No file selected.");
      return;
    }

    const formData = new FormData();
    formData.append('file', formFile.value);
    const response = await userContentsStore.postUserContentAsync(formData);

    // copyToClipboard(response.url);
    console.log("Link copied to clipboard.");
    formFile.value = null;
  } catch {
    console.log("An error has occured.");
    return;
  }
}
</script>

<template>
  <section class="container pt-28">
    <div class="flex justify-between mb-9">
      <p class="text-2xl font-bold">My Files</p>
      
      <div>
        <Dialog v-if="!selectionMode">
          <DialogTrigger>
            <Button variant="ghost" size="sm">Upload File</Button>
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
        <Button class="hover:bg-red-500" variant="ghost" size="sm" v-else-if="selectedUserContents.length > 0" @click="async () => await handleDeleteAsync()">Delete</Button>
        
        <Toggle size="sm" :pressed="selectionMode" @click="toggleSelectionMode()">Select</Toggle>
      </div>
    </div>
    
    <ul class="grid gap-x-4 gap-y-8 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4" v-if="userContents">
      <UserContentCard class="transition-all" :class="(selectionMode && !selectedUserContents.includes(userContent)) ? 'opacity-50 grayscale' : ''" v-for="userContent in userContents" :key="userContent.id" :userContent="userContent" @click="handleUserContentSelection($event, userContent)" />
    </ul>
  </section>
</template>