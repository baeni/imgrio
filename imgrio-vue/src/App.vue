<template>
  <router-view v-slot="{ Component, route }">
    <transition :name="`${route.meta.transition || 'fade' || 'slide-right'}`">
      <component :is="Component"
    /></transition>
  </router-view>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import { inject } from '@vercel/analytics';

import { useUserDetailsStore } from './stores/userDetails';
import { useMsal } from './composition-api/useMsal';
import { onMounted } from 'vue';
import { watch } from 'vue';

const userDetailsStore = useUserDetailsStore();
const msal = useMsal();
const accounts = msal.accounts.value;

inject();

onMounted(async () => {
  if (accounts.length !== 0) {
    await userDetailsStore.fetchUserDetails();
  }
});

watch(accounts, () => {
  if (accounts.length === 0) {
    userDetailsStore.userDetails = null;
    return;
  }

  userDetailsStore.fetchUserDetails();
});
</script>
