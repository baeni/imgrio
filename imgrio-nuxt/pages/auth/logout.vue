<template>
  <div class="section--center">
    <div class="section__container">
      <div class="section__container-title">
        <p>
          Tschau!
        </p>
      </div>
      <div class="section__container-description">
        <p>
          Du wirst in wenigen Sekunden weitergeleitet
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { signOutUser } from "~/composables/useSupabase";

onMounted(async () => {
  await signOutUser();
  setTimeout(() => {
    navigateTo("/");
  }, 3000);
});
</script>

<style scoped>
.section__container {
  color: #fff;
  text-align: center;
  max-width: 700px;
}

.section__container-title p {
  font-family: var(--font-family);
  font-weight: 700;
  font-size: 4rem;
  line-height: 115px;
}

.section__container-description {
  color: var(--color-lighter);
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 20px;
}
</style>