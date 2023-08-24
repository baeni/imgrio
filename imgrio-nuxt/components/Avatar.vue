<template>
  <NuxtLink to="/dashboard/settings" v-if="user">
    <img
      :src="`https://ui-avatars.com/api/?name=${(user as User).displayName}&background=random`"
    />
  </NuxtLink>
</template>

<script setup lang="ts">
import { User } from "firebase/auth";

const props = defineProps({
  user: {
    type: Object,
    required: true,
  },
});
</script>

<style scoped>
img {
  width: 2rem;
  border-radius: 10px;
}
</style>
