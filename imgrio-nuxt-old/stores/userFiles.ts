import { ref } from 'vue';
import { defineStore } from 'pinia';

import type { UserFile } from '@/models';
import { apiClient } from '@/axios.conf';

export const useUserFilesStore = defineStore('userFiles', () => {
  const userFiles = ref<UserFile[]>();

  async function fetchDataAsync() {
    userFiles.value = (await apiClient.get('me/files')).data.sort(
      (a: UserFile, b: UserFile) =>
        new Date(b.dateOfCreation).getTime() - new Date(a.dateOfCreation).getTime()
    );
  }

  async function postUserFileAsync(formData: FormData) {
    const response = (await apiClient.post('me/files', formData)).data;
    userFiles.value?.unshift(response.userFile);
    return response;
  }

  async function deleteUserFileAsync(userFileId: string) {
    const response = (await apiClient.delete(`me/files/${userFileId}`)).data;
    const index = userFiles.value?.findIndex(
      (selectedUserFile) => selectedUserFile.id == userFileId
    );
    userFiles.value?.splice(index!, 1);
    return response;
  }

  return { fetchDataAsync, postUserFileAsync, deleteUserFileAsync, userFiles };
});
