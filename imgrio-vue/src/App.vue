<script setup lang="ts">
import { RouterView } from 'vue-router';

import { useUserDetailsStore } from './stores/userDetails';
import { useMsal } from './composition-api/useMsal';
import { onMounted } from 'vue';
import { watch } from 'vue';

const userDetailsStore = useUserDetailsStore();
const msal = useMsal();
const accounts = msal.accounts.value;

onMounted(() => {
  if (accounts.length !== 0) {
    userDetailsStore.fetchUserDetails();
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

<template>
  <RouterView />
</template>
