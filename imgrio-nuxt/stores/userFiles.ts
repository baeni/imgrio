import { ref } from "vue";
import { defineStore } from "pinia";

import type { UserFile } from "@/models";
import { apiClient } from "@/axios.conf";

export const useUserFilesStore = defineStore("userFilesStore", () => {
  const userFiles = ref<UserFile[]>();

  async function fetchUserFiles() {
    const user = useUser().value;

    if (!user) {
      return new Error("Not authenticated");
    }

    userFiles.value = (
      await apiClient.get(`files/users/${user.uid}`)
    ).data.sort(
      (a: UserFile, b: UserFile) =>
        new Date(b.dateOfCreation).getTime() -
        new Date(a.dateOfCreation).getTime()
    );
  }

  return { fetchUserFiles, userFiles };
});
