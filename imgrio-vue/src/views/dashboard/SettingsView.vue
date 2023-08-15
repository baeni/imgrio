<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>Einstellungen</h1>
    </div>
    <form class="section__container-form" v-if="userDetails">
      <div class="section__container-form-input-group">
        <label for="firstName">Vorname</label>
        <TextField id="firstName" :value="userDetails.givenName" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="lastName">Nachname</label>
        <TextField id="lastName" :value="userDetails.surname" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="email">Email</label>
        <TextField id="email" :value="userDetails.mail" type="email" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="imageAnimation">Bild-Animation</label>
        <Dropdown
          id="imageAnimation"
          :options="[
            { key: 'Inaktiv', value: false },
            { key: 'Aktiv', value: true }
          ]"
        />
      </div>

      <div class="section__container-form-input-group">
        <label for="externalHost">Datei-Server</label>
        <Dropdown
          id="externalHost"
          :options="[
            { key: 'imgrio', value: false },
            { key: 'Eigener', value: true }
          ]"
        />
      </div>

      <div class="section__container-form-input-group">
        <label for="externalHost">Sprache</label>
        <Dropdown
          id="language"
          :options="[
            { key: 'Deutsch', value: 'de' },
            { key: 'English', value: 'en' }
          ]"
        />
      </div>

      <div class="section__container-form-input-group">
        <label for="firstName">Access Token</label>
        <Knob text="Neu generieren" small @click="() => getPermanentJwtAsync()" />
      </div>

      <div class="section__container-form-button">
        <Knob
          text="Änderungen speichern"
          small
          transparent
          @click="() => toast.success('Änderungen gespeichert.')"
        />
      </div>
    </form>
    <div class="section__container-loading" v-else>Lädt ...</div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { apiClient } from '@/axios';
import { useUserDetailsStore } from '@/stores/userDetails';
import type { User } from '@microsoft/microsoft-graph-types';
import { useToast } from 'vue-toastification';

import TextField from '@/components/inputs/TextField.vue';
import Dropdown from '@/components/inputs/Dropdown.vue';
import Knob from '@/components/inputs/Knob.vue';

const toast = useToast();

const userDetailsStore = useUserDetailsStore();
const userDetails = computed(() => userDetailsStore.userDetails);

async function getPermanentJwtAsync() {
  try {
    const response = (await apiClient.get(`users/${userDetails.value.id}`)).data;

    copyToClipboard(response);
    toast.success('Neuer Token in Zwischenablage kopiert');
  } catch {
    toast.error('Ein Fehler ist aufgetreten, versuche es erneut.');
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
