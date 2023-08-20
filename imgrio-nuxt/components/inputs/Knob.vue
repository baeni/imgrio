<template>
  <a
    v-if="href"
    :href="href"
    :class="`btn ${primary ? 'btn--primary' : 'btn--secondary'}
                 ${small ? 'btn--small' : 'btn--large'}
                 ${transparent ? 'btn--transparent' : ''}
                 ${hover ? 'btn--hover' : ''}`"
    >{{ text }}
  </a>

  <button
    v-else
    type="submit"
    :class="`btn ${primary ? 'btn--primary' : 'btn--secondary'}
                 ${small ? 'btn--small' : 'btn--large'}
                 ${transparent ? 'btn--transparent' : ''}
                 ${hover ? 'btn--hover' : ''}`"
  >
    {{ text }}
  </button>
</template>

<script setup lang="ts">
const props = defineProps({
  text: {
    type: String,
    required: true,
  },
  href: {
    type: String,
    default: null,
  },
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
  hover: {
    type: Boolean,
    default: true,
  },
})
</script>

<style scoped>
.btn {
  display: inline-block;
  margin: 0.5rem;
  font-family: var(--font-family);
  line-height: 25px;
  cursor: pointer;
  border-radius: 10px;
  transition: all 0.2s ease-in-out;
}

.btn--small {
  padding: 0.5rem 1.25rem;
  font-size: 0.9rem;
  font-weight: 600;
}

.btn--large {
  padding: 0.65rem 2rem;
  font-size: 1rem;
  font-weight: 700;
}

.btn--primary {
  background-color: var(--color-primary);
  color: #000;
}

.btn--secondary {
  background-color: var(--color-dark);
  color: #fff;
}

.btn--transparent {
  margin: 0;
  padding-inline: 0;
  background: transparent;
  color: #fff;
}

.btn--hover:hover {
  filter: brightness(0.8);
}
</style>
