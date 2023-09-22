<script setup lang="ts">
import { ref } from 'vue';
import { UserContent } from '@/models';
import { useUserContentsStore } from '@/stores/userContents';
import UserContentCard from '@/components/UserContentCard.vue';
import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import { Label } from '@/components/ui/label';

const props = defineProps({
  userContents: {
    type: Array as () => UserContent[],
    required: true
  }
});

const userContentsStore = useUserContentsStore();

const formFile = ref<File | null>(null);

const selectionMode = ref<boolean>(false);
const selectedUserContents = ref<UserContent[]>([]);

const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files.length > 0) {
    formFile.value = input.files[0];
  }
};

async function handlePostAsync() {
  try {
    if (formFile.value == null) {
      console.log('No file selected.');
      return;
    }

    const formData = new FormData();
    formData.append('file', formFile.value);
    const response = await userContentsStore.postUserContentAsync(formData);

    // copyToClipboard(response.url);
    console.log('Link copied to clipboard.');
    formFile.value = null;
  } catch {
    console.log('An error has occured.');
    return;
  }
}

function toggleSelectionMode() {
  selectedUserContents.value.length = 0;
  selectionMode.value = !selectionMode.value;
}

function handleContentCardClick(event: Event, userContent: UserContent) {
  if (!selectionMode.value) {
    return;
  }

  handleUserContentSelection(event, userContent);
}

function handleUserContentSelection(event: Event, userContent: UserContent) {
  if (!selectionMode.value) {
    toggleSelectionMode();
  }

  event.preventDefault();

  if (!selectedUserContents.value.includes(userContent)) {
    selectedUserContents.value.push(userContent);
  } else {
    const index = selectedUserContents.value.findIndex((x) => x == userContent);
    selectedUserContents.value.splice(index, 1);
  }
}

async function handleDeleteAsync() {
  try {
    const deletePromises = selectedUserContents.value.map((selectedUserContent) => {
      return userContentsStore.deleteUserContentAsync(selectedUserContent.id);
    });
    const response = await Promise.all(deletePromises);

    toggleSelectionMode();
  } catch {
    console.log('An error has occured.');
    return;
  }
}
</script>

<template>
  <span class="flex gap-0.5 justify-end mb-2">
    <Button
      class="hover:bg-red-500"
      variant="ghost"
      size="sm"
      @click="async () => await handleDeleteAsync()"
      v-if="selectedUserContents.length > 0"
      >Delete {{ selectedUserContents.length }}</Button
    >
    <Button variant="ghost" size="sm" @click="toggleSelectionMode()" v-if="selectionMode"
      >Cancel</Button
    >
    <Dialog v-else>
      <DialogTrigger>
        <Button variant="ghost" size="sm">Upload File</Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Upload File</DialogTitle>
          <DialogDescription> Files with up to 10 MB allowed. </DialogDescription>
        </DialogHeader>
        <div
          class="rounded-lg transition-colors border-2 border-dashed border-zinc-400 border-opacity-50 lg:hover:border-opacity-100"
        >
          <input class="hidden" id="file" type="file" accept="" @change="handleFileChange" />
          <Label class="p-10 text-center select-none cursor-pointer" for="file"
            >Drag'n'Drop file here<br />or select</Label
          >
        </div>
        <DialogFooter>
          <Button @click="async () => await handlePostAsync()"> Upload </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  </span>

  <ul class="grid gap-x-4 gap-y-8 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
    <li class="group relative" v-for="userContent in userContents">
      <UserContentCard
        class="transition-all"
        :class="selectionMode && !selectedUserContents.includes(userContent) ? 'opacity-50' : ''"
        :key="userContent.id"
        :userContent="userContent"
        @click="handleContentCardClick($event, userContent)"
      />
      <Button
        class="absolute top-2 right-2 transition-opacity lg:group-hover:opacity-30 lg:hover:!opacity-100"
        :class="selectionMode ? '!opacity-100' : 'opacity-30 lg:opacity-0'"
        variant="secondary"
        size="sm"
        @click="handleUserContentSelection($event, userContent)"
      >
        {{ !selectedUserContents.includes(userContent) ? 'Select' : 'Unselect' }}
      </Button>
    </li>
  </ul>
</template>

<style scoped></style>
