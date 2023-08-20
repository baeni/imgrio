<template>
  <input :type="type" :value="value" :disabled="disabled" />
</template>

<script setup lang="ts">
const props = defineProps({
  value: {
    required: true,
  },
  type: {
    type: String,
    default: 'text',
  },
  disabled: {
    type: Boolean,
    default: false,
  },
})
</script>

<style scoped>
input {
  padding: 0.75rem 1rem;
  box-sizing: border-box;
  font-family: var(--font-family);
  font-size: 0.9rem;
  background: var(--color-dark);
  color: var(--color-light);
  border: none;
  border-radius: 10px;
  outline: none;
}

input:disabled {
  filter: brightness(0.5);
  cursor: not-allowed;
}
</style>
