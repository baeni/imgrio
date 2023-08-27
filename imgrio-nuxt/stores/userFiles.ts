import { ref } from "vue";
import { getAuth } from "firebase/auth";
import { defineStore } from "pinia";

import type { UserFile } from "@/models";
import { apiClient } from "@/axios.conf";

export const useUserFilesStore = defineStore("userFilesStore", () => {
  const userFiles = ref<UserFile[]>();

  async function fetchUserFiles() {
    const currentUser = getAuth().currentUser;

    if (!currentUser) {
      return new Error("Not authenticated");
    }

    userFiles.value = (
      await apiClient.get(`files/users/${currentUser.uid}`)
    ).data.sort(
      (a: UserFile, b: UserFile) =>
        new Date(b.dateOfCreation).getTime() -
        new Date(a.dateOfCreation).getTime()
    );
  }

  return { fetchUserFiles, userFiles };
});
