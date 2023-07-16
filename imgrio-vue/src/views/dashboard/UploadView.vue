<script setup lang="ts">
import { ref } from 'vue';

import Knob from '../../components/Knob.vue';

const file = ref(null);
</script>

<template>
  <div class="section--center">
    <div class="section__container">
      <div class="section__container-title">
        <h1>Datei Hochladen</h1>
      </div>
      <form class="section__container-form">
        <label class="section__container-form-drop-area" for="input">
          <div class="section__container-form-drop-area-icon">
            <img src="../../assets/icons/image.svg" />
          </div>
          <div class="section__container-form-drop-area-title">
            <p>
              Datei hierher ziehen <br />
              oder auswählen
            </p>
          </div>
          <input
            type="file"
            accept="image/*"
            id="input"
            name="file"
            required
            hidden
            :value="file"
          />
        </label>
        <Knob :text="`${file} Hochladen`" primary />
      </form>
    </div>
  </div>
</template>

<style scoped>
.section__container {
  color: #fff;
  text-align: center;
}

.section__container-title {
  padding-bottom: 1rem;
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 55px;
}

.section__container-subtitle {
  color: var(--color-title);
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 25px;
}

.section__container-form-drop-area {
  display: block;
  padding: 10rem 20rem;
  margin-bottom: 1rem;
  border: 2px dashed var(--color-dark);
  border-radius: 10px;
  cursor: pointer;
  transition: border 0.1s ease-in-out;
}

.section__container-form-drop-area:hover {
  border: 2px dashed var(--color-primary);
}

.section__container-form-drop-area-icon img {
  width: 3rem;
  padding-bottom: 2rem;
}

.section__container-form-drop-area-title {
  color: var(--color-light);
  font-family: var(--font-family);
  font-size: 1.25rem;
  line-height: 30px;
}
</style>
