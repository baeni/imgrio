<template>
  <div class="section--center gradient__bg">
    <div class="section__container">
      <div class="section__container-slogan">
        <p>
          {{ $t("pages.index.slogan") }}
          <!-- Take. Give.
          <span class="section__container-slogan--accent">Share.</span> -->
        </p>
      </div>
      <div class="section__container-description">
        <p>
          {{ $t("pages.index.description") }}
        </p>
      </div>
      <div class="section__container-buttons">
        <Knob :text="$t('components.inputs.knob.go')" href="/sharex" />
        <Knob
          :text="$t('components.inputs.knob.dashboard')"
          href="/dashboard/files"
          primary
          v-if="user"
        />
        <LoginButton primary v-else />
      </div>
      <div class="section__container-statistics">
        <p>
          <span class="section__container-statistics--bold">{{
            data.count
          }}</span>
          {{ $t("pages.index.statistics") }}
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { reactive } from "vue";
import { apiClient } from "@/axios.conf";

import Knob from "@/components/inputs/Knob.vue";
import LoginButton from "@/components/LoginButton.vue";

const user = useSupabaseUser();

let data = reactive({
  count: 0,
  countToday: 0,
});

const fetchData = async () => {
  try {
    const response = (await apiClient.get("files")).data;
    data.count = response.count;
    data.countToday = response.countToday;
  } catch (error) {
    console.error("An error occurred while attempting to fetch data:", error);
  }
};

fetchData();
</script>

<style scoped>
.section__container {
  color: #fff;
  text-align: center;
  max-width: 700px;
}

.section__container-slogan p {
  font-family: var(--font-family);
  font-weight: 700;
  font-size: 4rem;
  line-height: 115px;
}

.section__container-slogan--accent {
  font-family: var(--font-family-brand);
  font-size: 4.5rem;
  color: var(--color-primary);
}

.section__container-description {
  color: var(--color-lighter);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 20px;
}

.section__container-buttons {
  margin-block: 2rem 0.75rem;
}

.section__container-statistics {
  font-family: var(--font-family);
  font-size: 0.75rem;
  color: var(--color-light);
  opacity: 0.5;
}

.section__container-statistics--bold {
  font-weight: 800;
}
</style>
