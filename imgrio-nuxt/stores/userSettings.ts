import { ref } from 'vue';
import { defineStore } from 'pinia';

import type { UserSetting } from '@/models';
import { apiClient } from '@/axios.conf';

export const useUserSettingsStore = defineStore('userSettings', () => {
  const userSettings = ref<UserSetting[]>();

  async function fetchDataAsync() {
    userSettings.value = (await apiClient.get('me/settings')).data;
  }

  async function putUserSettingAsync(key: string, value: string) {
    await apiClient.put('me/settings', { key, value });
  }

  return { fetchDataAsync, putUserSettingAsync, userSettings };
});
