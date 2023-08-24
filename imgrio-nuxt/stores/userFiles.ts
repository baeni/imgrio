import { ref } from "vue";
import { defineStore } from "pinia";

import type { UserFile } from "@/models";
import { apiClient } from "@/axios.config";

export const useUserFilesStore = defineStore("userFilesStore", () => {
  const userFiles = ref<UserFile[]>();

  async function fetchUserFiles() {
    const currentUser = useCurrentUser();

    userFiles.value = (
      await apiClient.get(`files/users/${currentUser.value?.uid}`)
    ).data.sort(
      (a: UserFile, b: UserFile) =>
        new Date(b.dateOfCreation).getTime() -
        new Date(a.dateOfCreation).getTime()
    );
  }

  return { fetchUserFiles, userFiles };
});
