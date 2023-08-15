<template>
  <RouterView />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import { inject } from '@vercel/analytics';

import { useHead } from '@vueuse/head';

import { useUserDetailsStore } from './stores/userDetails';
import { useMsal } from './composition-api/useMsal';
import { onMounted } from 'vue';
import { watch } from 'vue';

const userDetailsStore = useUserDetailsStore();
const msal = useMsal();
const accounts = msal.accounts.value;

inject();

useHead({
  meta: [
    {
      name: 'description',
      content:
        'imgrio ist eine Plattform zum Teilen von Dateien. Aktuell ist der vollumfängliche Zugriff nur für ausgewählte Personen möglich.'
    }
  ]
});

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
