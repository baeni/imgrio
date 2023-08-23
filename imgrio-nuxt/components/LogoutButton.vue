<template>
  <Knob
    text="Abmelden"
    @click="signOutUser"
    :small="small"
    :primary="primary"
    :transparent="transparent"
  />
</template>

<script setup lang="ts">
import { signOutUser } from "../composables/useFirebase";

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
