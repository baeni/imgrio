import { ref } from 'vue';
import { defineStore } from 'pinia';

import type { UserFile } from '@/models/UserFile';
import { useUserDetailsStore } from './userDetails';
import { apiClient } from '@/axios';

export const useUserFilesStore = defineStore('userFilesStore', () => {
  const userFiles = ref<UserFile[]>();

  async function fetchUserFiles() {
    const userDetailsStore = useUserDetailsStore();

    userFiles.value = (await apiClient.get(`files/users/${userDetailsStore.userDetails.id}`)).data;
  }

  return { fetchUserFiles, userFiles };
});
