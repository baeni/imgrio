<template>
  <NuxtLink to="/dashboard/settings" v-if="user">
    <img
      :src="`https://ui-avatars.com/api/?name=${user.user_metadata.full_name}&background=random`"
    />
  </NuxtLink>
</template>

<script setup lang="ts">
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
