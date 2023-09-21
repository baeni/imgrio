<template>
  <main class="flex h-screen bg-gradient-to-br from-blue-800 to-black">
    <div class="m-auto text-center">
      <h1 class="text-6xl font-bold mb-4">Take. Give. Share.</h1>
      <p class="text-lg mb-8">
        imgrio is a file sharing platform. Currently, full access is only available to selected
        people.
      </p>
      <div class="grid grid-cols-2 gap-2 w-full mx-auto mb-8">
        <Button>Request</Button>
      </div>
      <div class="grid grid-cols-2 gap-2 w-fit mx-auto mb-2">
        <Button variant="secondary" size="lg">Lets Go</Button>
        <Button size="lg">Dashboard</Button>
      </div>
      <p class="text-sm opacity-50">14 files are currently being shared thanks to imgrio!</p>
    </div>
  </main>

  <!--  <div class="section&#45;&#45;center gradient__bg">-->
  <!--    <div class="section__container">-->
  <!--      <div class="section__container-slogan">-->
  <!--        <p>-->
  <!--          {{ $t('pages.index.slogan') }}-->
  <!--          &lt;!&ndash; Take. Give.-->
  <!--          <span class="section__container-slogan&#45;&#45;accent">Share.</span> &ndash;&gt;-->
  <!--        </p>-->
  <!--      </div>-->
  <!--      <div class="section__container-description">-->
  <!--        <p>-->
  <!--          {{ $t('pages.index.description') }}-->
  <!--        </p>-->
  <!--      </div>-->
  <!--      <div class="section__container-buttons">-->
  <!--        <Button variant="default">Test</Button>-->
  <!--        <Knob :text="$t('components.inputs.knob.go')" href="/sharex" />-->
  <!--        <Knob-->
  <!--          :text="$t('components.inputs.knob.dashboard')"-->
  <!--          href="/dashboard/files"-->
  <!--          primary-->
  <!--          v-if="user"-->
  <!--        />-->
  <!--        <LoginButton primary v-else />-->
  <!--      </div>-->
  <!--      <div class="section__container-statistics">-->
  <!--        <p>-->
  <!--          <span class="section__container-statistics&#45;&#45;bold">{{ userFilesInfo.count }}</span>-->
  <!--          {{ $t('pages.index.statistics') }}-->
  <!--        </p>-->
  <!--      </div>-->
  <!--    </div>-->
  <!--  </div>-->
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { apiClient } from '@/axios.conf';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import Knob from '@/components/inputs/Knob.vue';
import LoginButton from '@/components/LoginButton.vue';
import { UserFilesInfo } from '~/models';

const user = useSupabaseUser();
const userFilesInfo = ref<UserFilesInfo>({
  count: 0,
  countToday: 0
});

onMounted(async () => {
  userFilesInfo.value = (await apiClient.get('files')).data;
});
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
