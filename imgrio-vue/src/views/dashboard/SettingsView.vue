<template>
  <div class="section__container section--margin">
    <div class="section__title">
      <h1>Einstellungen</h1>
    </div>
    <form class="section__container-form" v-if="userDetails">
      <div class="section__container-form-input-group">
        <label for="firstName">Vorname</label>
        <input type="text" id="firstName" :value="userDetails.givenName" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="lastName">Nachname</label>
        <input type="text" id="lastName" :value="userDetails.surname" disabled />
      </div>

      <div class="section__container-form-input-group">
        <label for="email">Email</label>
        <input type="email" id="email" :value="userDetails.mail" disabled />
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

      <div class="section__container-form-input-group">
        <label for="firstName">Access Token</label>
        <div>
          <Knob
            text="Neuen Token generieren"
            small
            @click="() => toast.success('Neuer Token in Zwischenablage kopiert')"
          />
        </div>
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
import { useUserDetailsStore } from '@/stores/userDetails';
import type { User } from '@microsoft/microsoft-graph-types';
import { useToast } from 'vue-toastification';

import Knob from '@/components/inputs/Knob.vue';

const toast = useToast();

const userDetailsStore = useUserDetailsStore();
const userDetails = computed(() => userDetailsStore.userDetails) as User;
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
.section__container-form-input-group select {
  flex: 2.75;
  padding: 0.75rem 1rem;
  box-sizing: border-box;
  font-family: var(--font-family);
  font-size: 0.9rem;
  background: var(--color-dark);
  color: var(--color-light);
  border: none;
  border-radius: 10px;
  outline: none;
}

.section__container-form-input-group select {
  appearance: none;
  background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='white' stroke-width='3' stroke-linecap='round' stroke-linejoin='round'%3e%3cpolyline points='6 9 12 15 18 9'%3e%3c/polyline%3e%3c/svg%3e");
  background-repeat: no-repeat;
  background-position: right 1rem center;
  background-size: 1rem;
}

.section__container-form-input-group div {
  flex: 2.75;
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

.section__container-loading {
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 30px;
}
</style>
