// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  css: ['@/assets/css/main.css', '@fortawesome/fontawesome-svg-core/styles.css'],
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    }
  },
  
  modules: ['@pinia/nuxt', '@nuxtjs/supabase'],

  runtimeConfig: {
    public: {
      siteUrl: process.env.SITE_URL
    }
  },

  supabase: {
    redirectOptions: {
      login: '/auth/login',
      callback: '/',
      exclude: ['/', '/v/*']
    }
  }
})