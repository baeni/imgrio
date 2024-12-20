<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>{{ $t('pages.dashboard.settings.title') }}</h1>
    </div>
    <form class="section__container-form" v-if="user && userSettings">
      <div class="section__container-form-input-group">
        <label for="username">{{ $t('pages.dashboard.settings.username') }}</label>
        <Textfield id="username" :value="user.user_metadata.full_name" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="email">{{ $t('pages.dashboard.settings.email') }}</label>
        <Textfield id="email" :value="user.email" type="email" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="imageAnimation">{{ $t('pages.dashboard.settings.imageAnimation') }}</label>
        <Dropdown
          id="imageAnimation"
          :options="['false', 'true']"
          :selected="userSettings.imageAnimation"
        />
      </div>

      <div class="section__container-form-input-group">
        <label for="accessToken">{{ $t('pages.dashboard.settings.accessToken') }}</label>
        <Knob
          id="accessToken"
          :text="$t('pages.dashboard.settings.regenerate')"
          small
          @click.prevent="async () => await getPermanentJwtAsync()"
        />
      </div>

      <div class="section__container-form-button">
        <Knob :text="$t('pages.dashboard.settings.save')" small transparent />
      </div>
    </form>
    <div class="section__container-loading grid place-items-center" v-else>
      <Loading />
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { apiClient } from '@/axios.conf';
import { useToast } from 'vue-toastification';
import { useUserSettingsStore } from '~/stores/userSettings';

import Textfield from '~/components/inputs/Textfield.vue';
import Dropdown from '~/components/inputs/Dropdown.vue';
import Knob from '~/components/inputs/Knob.vue';
import { UserSetting } from '~/models';

const user = useSupabaseUser();
const i18n = useI18n();
const toast = useToast();

const userSettingsStore = useUserSettingsStore();

onMounted(async () => {
  await userSettingsStore.fetchDataAsync();
});

const userSettings = computed(() => userSettingsStore.userSettings as UserSetting[]);

async function getPermanentJwtAsync() {
  if (!user) {
    return new Error('Not authenticated');
  }

  try {
    const response = (await apiClient.get('me/token')).data;

    copyToClipboard(response);
    toast.success(i18n.t('toasts.successTokenCopied'));
  } catch {
    toast.error(i18n.t('toasts.errorRetry'));
    return;
  }
}

function copyToClipboard(text: string) {
  navigator.clipboard.writeText(text);
}
</script>

<style scoped>
.section__container {
  color: #fff;
}

.section__container-form {
  display: flex;
  flex-direction: column;
}

.section__container-form-input-group {
  display: flex;
  margin-block-end: 2.5rem;
  align-items: center;
  gap: 25px;
}

.section__container-form-input-group label {
  flex: 1;
  text-align: right;
  padding: 0.5rem;
  font-family: var(--font-family);
  font-weight: 500;
  font-size: 1rem;
  line-height: 30px;
  color: var(--color-light);
}

.section__container-form-input-group input,
.section__container-form-input-group select,
.section__container-form-input-group submit {
  flex: 2.75;
  margin: 0;
}

.section__container-form-button {
  margin: 0 auto;
}

.section__container-loading {
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 30px;
}
</style>
