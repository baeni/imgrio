<script setup lang="ts">
import { ref } from 'vue';
import { InteractionType } from '@azure/msal-browser';
import { msalInstance } from '@/authConfig';
import { Client } from '@microsoft/microsoft-graph-client';
import type { User } from '@microsoft/microsoft-graph-types';
import {
  AuthCodeMSALBrowserAuthenticationProvider,
  type AuthCodeMSALBrowserAuthenticationProviderOptions
} from '@microsoft/microsoft-graph-client/authProviders/authCodeMsalBrowser';
import { useToast } from 'vue-toastification';

import Knob from '@/components/Knob.vue';
import { onMounted } from 'vue';

const account = msalInstance.getActiveAccount() ?? msalInstance.getAllAccounts()[0];

const options: AuthCodeMSALBrowserAuthenticationProviderOptions = {
  account: account,
  interactionType: InteractionType.Redirect,
  scopes: ['user.read', 'mail.send']
};

const client = Client.initWithMiddleware({
  authProvider: new AuthCodeMSALBrowserAuthenticationProvider(msalInstance, options)
});

const userDefails = ref<User | null>(null);

onMounted(async () => {
  try {
    userDefails.value = await client.api('/me').get();
  } catch (error) {
    throw error;
  }
});

const toast = useToast();
</script>

<template>
  <div class="section__container section--margin">
    <div class="section__container-title section__title">
      <h1>Einstellungen</h1>
    </div>
    <form class="section__container-form">
      <div class="section__container-form-input-group">
        <label for="firstName">Vorname</label>
        <input type="text" id="firstName" :value="userDefails?.givenName" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="lastName">Nachname</label>
        <input type="text" id="lastName" :value="userDefails?.surname" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="email">Email</label>
        <input type="email" id="email" :value="userDefails?.mail" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="imageAnimation">Bild-Animation</label>
        <select id="imageAnimation">
          <option value="false">Inaktiv</option>
          <option value="true">Aktiv</option>
        </select>
      </div>

      <div class="section__container-form-input-group">
        <label for="externalHost">Datei-Server</label>
        <select id="externalHost">
          <option value="false">imgrio</option>
          <option value="true">Eigener</option>
        </select>
      </div>

      <div class="section__container-form-input-group">
        <label for="externalHost">Sprache</label>
        <select id="externalHost">
          <option value="de-de">Deutsch</option>
          <option value="en-us">Englisch</option>
        </select>
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
  </div>
</template>

<style scoped>
.section__container {
  color: #fff;
}

.section__container-title {
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 55px;
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
.section__container-form-input-group select {
  flex: 2.75;
  padding: 0.5rem 1rem;
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 30px;
  background: var(--color-dark);
  color: var(--color-light);
  border: none;
  border-radius: 10px;
  outline: none;
}

.section__container-form-input-group input:disabled,
.section__container-form-input-group select:disabled {
  filter: brightness(0.5);
  cursor: not-allowed;
}

.section__container-form-input-group select {
  cursor: pointer;
}

.section__container-form-button {
  margin: 0 auto;
}
</style>
