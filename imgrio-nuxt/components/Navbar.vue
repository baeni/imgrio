<script setup lang="ts">
import { ref } from 'vue';
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

const destinations = [
  {
    title: 'Home',
    url: '/'
  },
  {
    title: 'ShareX',
    url: '/sharex'
  },
  {
    title: 'Dashboard',
    url: '/dashboard/files'
  }
];

const showMobileMenu = ref<Boolean>(false);
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

      <div class="hidden lg:grid grid-cols-3 gap-0.5">
        <NuxtLink :to="destination.url" v-for="destination in destinations">
          <Button class="w-full" variant="ghost">{{ destination.title }}</Button>
        </NuxtLink>
      </div>

      <div class="hidden lg:block" v-if="user">
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

            <a href="https://paypal.me/baeniD7KN5JMJM6SE6" target="_blank">
              <DropdownMenuItem>
                <FaIcon class="mr-2 w-4 h-4" :icon="['fas', 'mug-hot']" />
                <span>Donate</span>
              </DropdownMenuItem>
            </a>

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

      <!-- Mobile Menu Trigger -->
      <div class="cursor-pointer z-10 lg:hidden" @click="showMobileMenu = !showMobileMenu">
        <svg
          width="36px"
          height="36px"
          viewBox="0 0 24 24"
          xmlns="http://www.w3.org/2000/svg"
          v-if="!showMobileMenu"
        >
          <path d="M4 10H20M4 14H20" stroke="#ffffff" stroke-width="1" />
        </svg>

        <svg
          width="36px"
          height="36px"
          viewBox="0 0 24 24"
          xmlns="http://www.w3.org/2000/svg"
          v-else
        >
          <path d="M19 5L4.99998 19M5.00001 5L19 19" stroke="#ffffff" stroke-width="1" />
        </svg>
      </div>
      <!---->
    </div>

    <!-- Mobile Menu-->
    <div
      class="absolute bg-zinc-900 w-screen transition-all ease-in-out"
      :class="showMobileMenu ? 'h-screen opacity-100' : 'h-0 opacity-0 invisible'"
    >
      <div class="grid grid-cols-1 gap-4 px-20 py-36 text-2xl">
        <NuxtLink
          class="!bg-transparent"
          :to="destination.url"
          @click="showMobileMenu = false"
          v-for="destination in destinations"
          >{{ destination.title }}</NuxtLink
        >
      </div>
    </div>
    <!---->
  </nav>
</template>
