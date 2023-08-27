<template>
  <Knob
    :text="$t('components.inputs.knob.signIn')"
    @click="signInUser"
    :small="small"
    :primary="primary"
    :transparent="transparent"
  />
</template>

<script setup lang="ts">
import { signInUser } from "../composables/useSupabase";

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
