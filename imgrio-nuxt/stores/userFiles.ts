import { ref } from "vue";
import { defineStore } from "pinia";

import type { UserFile } from "@/models";
import { useUserDetailsStore } from "./userDetails";
// import { apiClient } from '@/axios';

export const useUserFilesStore = defineStore("userFilesStore", () => {
  const userFiles = ref<UserFile[]>();

  async function fetchUserFiles() {
    const userDetailsStore = useUserDetailsStore();

    // userFiles.value = (
    //   await apiClient.get(`files/users/${userDetailsStore.userDetails.id}`)
    // ).data.sort(
    //   (a: UserFile, b: UserFile) =>
    //     new Date(b.dateOfCreation).getTime() - new Date(a.dateOfCreation).getTime()
    // );
  }

  return { fetchUserFiles, userFiles };
});
