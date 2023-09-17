<script setup lang="ts">
import {Button} from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from "@/components/ui/dropdown-menu";
import {
  Avatar,
  AvatarImage,
  AvatarFallback
} from "@/components/ui/avatar";

const props = defineProps({
  transparent: {
    type: Boolean,
    default: false
  }
});

const config = useRuntimeConfig();
const user = useSupabaseUser();
</script>

<template>
  <nav class="flex fixed justify-center w-full h-20 z-10 bg-opacity-50" :class="`${transparent ? 'bg-transparent backdrop-blur-0' : 'bg-zinc-950 backdrop-blur-2xl'}`">
    <div class="flex container justify-between items-center">
      <NuxtLink to="/">
        <img class="w-14" src="/logo192.png" alt="imgrio" />
      </NuxtLink>

      <div class="grid grid-cols-3">
        <NuxtLink to="/">
          <Button class="w-full" variant="ghost">Home</Button>
        </NuxtLink>
        <NuxtLink to="/sharex">
          <Button class="w-full" variant="ghost">ShareX</Button>
        </NuxtLink>
        <NuxtLink to="/dashboard/files">
          <Button class="w-full" variant="ghost">Dashboard</Button>
        </NuxtLink>
      </div>

      <div v-if="user">
        <DropdownMenu>
          <DropdownMenuTrigger class="flex gap-4 items-center">
            <p class="font-bold">Hi, {{ user.user_metadata.name }}</p>
                        
            <Avatar class="rounded-lg">
              <AvatarImage :src="user.user_metadata.picture" />
              <AvatarFallback>{{ user.user_metadata.name.slice(0, 2).toUpperCase() }}</AvatarFallback>
            </Avatar>
          </DropdownMenuTrigger>
          <DropdownMenuContent>
            <DropdownMenuItem><NuxtLink to="/dashboard/files">My Files</NuxtLink></DropdownMenuItem>
            <DropdownMenuItem><NuxtLink to="/dashboard/files">Upload File</NuxtLink></DropdownMenuItem>
            <DropdownMenuItem><NuxtLink to="/dashboard/settings">Settings</NuxtLink></DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem><NuxtLink :to="config.public.logoutPath!">Log Out</NuxtLink></DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
      <NuxtLink :to="config.public.loginPath!" v-else>
        <Button class="w-full" variant="outline">Log In</Button>
      </NuxtLink>
    </div>
  </nav>
</template>