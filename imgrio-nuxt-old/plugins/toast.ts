import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.use(Toast, {
    position: "top-right",
    hideProgressBar: true,
    closeButton: false,
    draggable: false,
    maxToasts: 1,
    timeout: 3000,
  });
});
