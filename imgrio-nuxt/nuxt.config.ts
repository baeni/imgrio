// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  css: ["@/assets/main.css", "@fortawesome/fontawesome-svg-core/styles.css"],
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    },
  },

  modules: ["@pinia/nuxt", "nuxt-vuefire", "@nuxtjs/i18n"],

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

  i18n: {
    // https://i18n.nuxtjs.org/options-reference/
    vueI18n: "./i18n.conf.ts",
    detectBrowserLanguage: false, // temporarily disabled
    locales: [
      { code: "de", iso: "de", file: "de.json" },
      { code: "en", iso: "en", file: "en.json" },
    ],
    langDir: "./locales",
    strategy: "no_prefix",
  },
});
