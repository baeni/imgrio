import { ref } from 'vue';
import { computed } from 'vue';
import { defineStore } from 'pinia';

import { useUserDetailsStore } from './userDetails';
import { apiClient } from '@/axios';

export const useUserFilesStore = defineStore('userFilesStore', () => {
  const userFiles = ref();

  async function fetchUserFiles() {
    const userDetailsStore = useUserDetailsStore();
    const userDetails = computed(() => userDetailsStore.userDetails);

    userFiles.value = apiClient.get(`files/users/${userDetails.value.id}`);
  }

  return { fetchUserFiles, userFiles };
});
