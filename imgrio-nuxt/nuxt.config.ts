// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  modules: ["@pinia/nuxt", "nuxt-vuefire"],

  runtimeConfig: {
    public: {
      firebaseApiKey: process.env.FIREBASE_API_KEY,
    },
  },

  vuefire: {
    config: {
      apiKey: process.env.FIREBASE_API_KEY,
      authDomain: "imgrio-b1ddc.firebaseapp.com",
      projectId: "imgrio-b1ddc",
      appId: "1:469817125060:web:81ca004d19dd661e0e4191",
      storageBucket: "imgrio-b1ddc.appspot.com",
      messagingSenderId: "469817125060",
      measurementId: "G-WNEXEH32BG",
    },
    auth: true,
  },
});
