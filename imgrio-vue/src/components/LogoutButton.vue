<script setup lang="ts">
import { useMsal } from '../composition-api/useMsal';

import Knob from './Knob.vue';

const { instance } = useMsal();

const props = defineProps({
  small: {
    type: Boolean,
    default: false
  },
  primary: {
    type: Boolean,
    default: false
  },
  transparent: {
    type: Boolean,
    default: false
  }
});

const logoutRedirect = () => {
  instance.logoutRedirect();
};
</script>

<template>
  <Knob
    text="Abmelden"
    @click="logoutRedirect"
    :small="small"
    :primary="primary"
    :transparent="transparent"
  />
</template>
