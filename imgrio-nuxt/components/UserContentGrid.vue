<script setup lang="ts">
import { ref, computed } from 'vue';
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
import { Input } from '@/components/ui/input';
import {
  AlertDialog,
  AlertDialogAction, AlertDialogCancel,
  AlertDialogContent, AlertDialogDescription,
  AlertDialogFooter, AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger
} from "~/components/ui/alert-dialog";
import {User} from "lucide-vue-next";

const props = defineProps({
  userContents: {
    type: Array as () => UserContent[],
    required: true
  }
});

const userContentsStore = useUserContentsStore();

const formFile = ref<File | null>(null);
const formTitle = ref<string | number | undefined>(undefined);

const selectionMode = ref<boolean>(false);
const selectedUserContents = ref<UserContent[]>([]);
const selectedUserContentsCount = computed(() => selectedUserContents.value.length);

const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files.length > 0) {
    const file = input.files[0];

    formFile.value = file;
    formTitle.value = file.name;
  }
};

async function handlePostAsync() {
  try {
    if (formFile.value == null) {
      console.log('No file selected.');
      return;
    }

    const formData = new FormData();
    formData.append('file', formFile.value, formTitle.value?.toString());
    const response = await userContentsStore.postUserContentAsync(formData);

    // copyToClipboard(response.url);
    console.log('Link copied to clipboard.');
    formFile.value = null;
  } catch (error) {
    console.log(`An error has occured: ${error}`);
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
      return userContentsStore.deleteUserContentAsync(selectedUserContent);
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
  <div class="flex gap-0.5 justify-end mb-4">
    <AlertDialog v-if="selectedUserContents.length > 0">
      <AlertDialogTrigger>
        <Button class="hover:bg-red-500" variant="secondary" size="sm">Delete {{ selectedUserContentsCount }}</Button>
      </AlertDialogTrigger>
      <AlertDialogContent>
        <AlertDialogHeader>
          <AlertDialogTitle>Are you sure?</AlertDialogTitle>
          <AlertDialogDescription>
            <p>Deleting files cannot be undone. Perform with caution!</p>
          </AlertDialogDescription>
        </AlertDialogHeader>
        <AlertDialogFooter>
          <AlertDialogCancel>Cancel</AlertDialogCancel>
          <AlertDialogAction class="hover:bg-red-500 hover:text-foreground" @click="async () => await handleDeleteAsync()">Yes, delete {{ selectedUserContentsCount }} {{ selectedUserContentsCount == 1 ? 'file' : 'files' }}</AlertDialogAction>
        </AlertDialogFooter>
      </AlertDialogContent>
    </AlertDialog>
    <Button variant="outline" size="sm" @click="toggleSelectionMode()" v-if="selectionMode"
      >Cancel</Button
    >
    <Dialog v-else>
      <DialogTrigger>
        <Button variant="outline" size="sm">Upload File</Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Upload File</DialogTitle>
          <DialogDescription> Files up to 10 MB allowed.</DialogDescription>
        </DialogHeader>
        <div
          class="rounded-lg transition-colors border-2 border-dashed border-zinc-800 lg:hover:border-zinc-700"
          :class="formFile ? 'hidden' : ''"
        >
          <Label class="p-10 text-center select-none cursor-pointer" for="file">
            <span class="block text-lg font-semibold">Drag & drop</span>
            <span class="block text-zinc-600">or browse file</span>
          </Label>
          <input class="hidden" id="file" type="file" @change="handleFileChange" />
        </div>
        <div v-if="formFile">
          <Input tabindex="-1" placeholder="File Name" v-model="formTitle" />
          <Label class="mt-2 ml-0.5 w-fit text-zinc-400 font-normal cursor-pointer" for="file"
            >browse</Label
          >
        </div>
        <DialogFooter>
          <DialogTrigger>
            <Button variant="outline">Cancel</Button>
          </DialogTrigger>
          <DialogTrigger>
            <Button @click="async () => await handlePostAsync()">Upload</Button>
          </DialogTrigger>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  </div>

  <ul class="grid gap-x-4 gap-y-8 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
    <li class="group relative" v-for="userContent in userContents">
      <UserContentCard
        class="transition-all"
        :class="selectionMode && !selectedUserContents.includes(userContent) ? 'opacity-50' : ''"
        :userContent="userContent"
        @click="handleContentCardClick($event, userContent)"
        v-if="userContent"
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
