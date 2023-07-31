<template>
  <Knob
    text="Anmelden"
    @click="loginRedirect"
    :small="small"
    :primary="primary"
    :transparent="transparent"
  />
</template>

<script setup lang="ts">
import { useMsal } from '../composition-api/useMsal';
import { loginRequest } from '../authConfig';

import Knob from './inputs/Knob.vue';

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

const loginRedirect = () => {
  instance.loginRedirect(loginRequest);
};
</script>
