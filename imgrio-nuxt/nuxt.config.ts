// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  modules: ["@pinia/nuxt"],
  auth: {
    strategies: {
      oidc: {
        scheme: "openIDConnect",
        clientId: "CLIENT_ID",
        endpoints: {
          configuration:
            "https://accounts.google.com/.well-known/openid-configuration",
        },
      },
    },
  },
});
