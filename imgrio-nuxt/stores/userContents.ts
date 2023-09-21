import { ref } from 'vue';
import { defineStore } from 'pinia';

import type { UserContent } from '@/models';
import { apiClient } from '@/axios.conf';

export const useUserContentsStore = defineStore('userContents', () => {
  const userContents = ref<UserContent[]>([]);

  async function fetchDataAsync() {
    userContents.value = (await apiClient.get('me/files')).data.sort(
      (a: UserContent, b: UserContent) =>
        new Date(b.dateOfCreation).getTime() - new Date(a.dateOfCreation).getTime()
    );
  }

  async function postUserContentAsync(formData: FormData) {
    const response = (await apiClient.post('me/files', formData)).data;
    userContents.value?.unshift(response.userContent);
    return response;
  }

  async function deleteUserContentAsync(userContentId: string) {
    const response = (await apiClient.delete(`me/files/${userContentId}`)).data;
    const index = userContents.value?.findIndex(
      (selectedUserContent) => selectedUserContent.id == userContentId
    );
    userContents.value?.splice(index!, 1);
    return response;
  }

  return { fetchDataAsync, postUserContentAsync, deleteUserContentAsync, userContents };
});
