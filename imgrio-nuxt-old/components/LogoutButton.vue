<template>
  <Knob
    :text="$t('components.inputs.knob.signOut')"
    @click="navigateTo('/auth/logout')"
    :small="small"
    :primary="primary"
    :transparent="transparent"
  />
</template>

<script setup lang="ts">
import Knob from "./inputs/Knob.vue";

const props = defineProps({
  small: {
    type: Boolean,
    default: false,
  },
  primary: {
    type: Boolean,
    default: false,
  },
  transparent: {
    type: Boolean,
    default: false,
  },
});
</script>
