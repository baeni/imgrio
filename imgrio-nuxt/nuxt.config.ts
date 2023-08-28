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

  modules: ["@pinia/nuxt", "@nuxtjs/i18n", "@nuxtjs/supabase"],
  build: { transpile: ["vue-toastification"] },

  runtimeConfig: {
    public: {},
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

  supabase: {
    redirectOptions: {
      login: "/",
      callback: "/",
      exclude: [],
    },
  },
});