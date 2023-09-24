<script setup lang="ts">
import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from '@/components/ui/dropdown-menu';
import { Avatar, AvatarImage, AvatarFallback } from '@/components/ui/avatar';

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
  <nav
    class="flex fixed w-full h-20 z-10 bg-opacity-50 border-zinc-600 border-opacity-20"
    :class="`${
      transparent
        ? 'bg-transparent backdrop-blur-0 border-b-0'
        : 'bg-zinc-950 backdrop-blur-2xl border-b'
    }`"
  >
    <div class="flex container justify-between items-center">
      <NuxtLink class="!bg-transparent" to="/">
        <img class="w-14" src="/logo192.png" alt="imgrio" />
      </NuxtLink>

      <div class="grid grid-cols-3 gap-0.5">
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
            <p class="font-semibold">Hi, {{ user.user_metadata.name }}</p>

            <Avatar class="rounded-lg">
              <AvatarImage :src="user.user_metadata.picture" />
              <AvatarFallback>{{
                user.user_metadata.name.slice(0, 2).toUpperCase()
              }}</AvatarFallback>
            </Avatar>
          </DropdownMenuTrigger>
          <DropdownMenuContent class="w-40 mt-0.5" avoid-collisions align="end">
            <DropdownMenuLabel>Dashboard</DropdownMenuLabel>
            <DropdownMenuSeparator />

            <NuxtLink to="/dashboard/files">
              <DropdownMenuItem>
                <FaIcon class="mr-2 w-4 h-4" :icon="['far', 'file-lines']" />
                <span>My Files</span>
              </DropdownMenuItem>
            </NuxtLink>

            <NuxtLink to="/dashboard/account">
              <DropdownMenuItem>
                <FaIcon class="mr-2 w-4 h-4" :icon="['fas', 'sliders']" />
                <span>Account</span>
              </DropdownMenuItem>
            </NuxtLink>

            <DropdownMenuSeparator />

            <DropdownMenuItem>
              <a href="https://www.buymeacoffee.com/bennysaa" target="_blank">
                <FaIcon class="mr-2 w-4 h-4" :icon="['fas', 'mug-hot']" />
                <span>Buy Me a Coffee</span>
              </a>
            </DropdownMenuItem>
            
            <DropdownMenuSeparator />

            <NuxtLink :to="config.public.logoutPath!">
              <DropdownMenuItem>
                <FaIcon class="mr-2 w-4 h-4" :icon="['fas', 'arrow-right-from-bracket']" />
                <span>Log Out</span>
              </DropdownMenuItem>
            </NuxtLink>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
      <NuxtLink :to="config.public.loginPath!" v-else>
        <Button class="w-full" variant="outline">Log In</Button>
      </NuxtLink>
    </div>
  </nav>
</template>
