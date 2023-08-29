<template>
  <select :disabled="disabled">
    <option v-for="option in options" :value="option">
      {{ option }}
    </option>
  </select>
</template>

<script setup lang="ts">
const props = defineProps({
  options: {
    type: Array,
    required: true
  },
  disabled: {
    type: Boolean,
    default: false
  }
});
</script>

<style scoped>
select {
  padding: 0.75rem 1rem;
  box-sizing: border-box;
  font-family: var(--font-family);
  font-size: 0.9rem;
  background: var(--color-dark);
  color: var(--color-light);
  border: none;
  border-radius: 10px;
  outline: none;
  appearance: none;
  background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='white' stroke-width='3' stroke-linecap='round' stroke-linejoin='round'%3e%3cpolyline points='6 9 12 15 18 9'%3e%3c/polyline%3e%3c/svg%3e");
  background-repeat: no-repeat;
  background-position: right 1rem center;
  background-size: 1rem;
  cursor: pointer;
}

select:disabled {
  opacity: 1;
  filter: brightness(0.5);
  cursor: not-allowed;
}
</style>
