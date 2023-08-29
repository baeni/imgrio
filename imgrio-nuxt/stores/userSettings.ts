import { ref } from 'vue';
import { defineStore } from 'pinia';

import type { UserSettings } from '@/models';
import { apiClient } from '@/axios.conf';

export const useUserSettingsStore = defineStore('useUserSettings', () => {
  const userSettings = ref<UserSettings>();

  async function fetchUserSettings() {
    const user = useSupabaseUser();

    if (!user) {
      return new Error('Not authenticated');
    }

    userSettings.value = (await apiClient.get(`users/settings/${user.value.id}`)).data;
  }

  return { fetchUserSettings, userSettings };
});
