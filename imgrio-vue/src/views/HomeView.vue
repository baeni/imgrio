<template>
  <div class="section--center gradient__bg">
    <div class="secion__container">
      <div class="secion__container-slogan">
        <p>Take. Give. <span class="secion__container-slogan--accent">Share.</span></p>
      </div>
      <div class="secion__container-description">
        <p>
          imgrio ist eine Plattform zum Teilen von Dateien. Aktuell ist der vollumfängliche Zugriff
          nur für ausgewählte Personen möglich.
        </p>
      </div>
      <div class="secion__container-buttons">
        <Knob text="Los gehts" href="/sharex" />
        <Knob text="Dashboard" href="/dashboard" primary v-if="isAuthenticated" />
        <LoginButton primary v-else />
      </div>
      <div class="secion__container-statistics">
        <p>
          <span class="secion__container-statistics--bold">{{ data.count }}</span> Dateien sind
          aktuell dank imgrio im Umlauf!
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useIsAuthenticated } from '@/composition-api/useIsAuthenticated';
import { reactive } from 'vue';
import { apiClient } from '@/axios';

import Knob from '@/components/inputs/Knob.vue';
import LoginButton from '@/components/LoginButton.vue';

const isAuthenticated = useIsAuthenticated();

let data = reactive({
  count: 0,
  countToday: 0
});

const fetchData = async () => {
  try {
    const response = await apiClient.get('files');
    data.count = response.data.count;
    data.countToday = response.data.countToday;
  } catch (error) {
    console.error('An error occurred while attempting to fetch data:', error);
  }
};

fetchData();
</script>

<style scoped>
.secion__container {
  color: #fff;
  text-align: center;
  max-width: 700px;
}

.secion__container-slogan p {
  font-family: var(--font-family);
  font-weight: 700;
  font-size: 4rem;
  line-height: 115px;
}

.secion__container-slogan--accent {
  font-family: var(--font-family-brand);
  font-size: 4.5rem;
  color: var(--color-primary);
}

.secion__container-description {
  color: var(--color-text);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 20px;
}

.secion__container-buttons {
  margin-block: 2rem 0.75rem;
}

.secion__container-statistics {
  font-family: var(--font-family);
  font-size: 0.75rem;
  color: var(--color-light);
  opacity: 0.5;
}

.secion__container-statistics--bold {
  font-weight: 800;
}
</style>
