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
      siteUrl: process.env.SUPABASE_SITE_URL,
      loginPath: process.env.SUPABASE_LOGIN_PATH,
      logoutPath: process.env.SUPABASE_LOGOUT_PATH,
      redirectPath: process.env.SUPABASE_REDIRECT_PATH
    }
  },

  supabase: {
    redirectOptions: {
      login: process.env.SUPABASE_LOGIN_PATH!,
      callback: process.env.SUPABASE_REDIRECT_PATH!,
      exclude: ['/', '/sharex', '/v/*']
    }
  }
})