import './assets/main.css';
import 'vue-toastification/dist/index.css';

import { createApp } from 'vue';
import { createPinia } from 'pinia';

import App from './App.vue';
import router from './router';
import { msalPlugin } from './plugins/msalPlugin';
import { msalInstance } from './authConfig';
import Toast from 'vue-toastification';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(msalPlugin, msalInstance);
app.use(Toast, {
  transition: 'Vue-Toastification__fade',
  position: 'top-center',
  closeButton: false,
  draggable: false,
  maxToasts: 1,
  timeout: 3000
});

app.mount('#app');
