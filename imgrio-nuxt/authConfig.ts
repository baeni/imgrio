import { LogLevel, PublicClientApplication } from "@azure/msal-browser";

export const msalConfig = {
  auth: {
    clientId: "a2e1cc16-6af7-4986-8efc-d8d7e614daa2",
    authority:
      "https://login.microsoftonline.com/870c73fe-c22b-46ff-87c3-b7bf53ed6125",
    redirectUri: "/dashboard",
    postLogoutRedirectUri: "/",
  },
  cache: {
    cacheLocation: "localStorage",
  },
  system: {
    loggerOptions: {
      loggerCallback: (
        level: LogLevel,
        message: string,
        containsPii: boolean
      ) => {
        if (containsPii) {
          return;
        }
        switch (level) {
          case LogLevel.Error:
            console.error(message);
            return;
          case LogLevel.Info:
            console.info(message);
            return;
          case LogLevel.Verbose:
            console.debug(message);
            return;
          case LogLevel.Warning:
            console.warn(message);
            return;
          default:
            return;
        }
      },
      logLevel: LogLevel.Verbose,
    },
  },
};

export const msalInstance = new PublicClientApplication(msalConfig);

export const loginRequest = {
  scopes: ["api://d9bf5b2c-ee47-40fd-8b61-cc6cd86d2582/access_as_user"],
};

// // Add here the endpoints for MS Graph API services you would like to use.
// export const graphConfig = {
//   graphMeEndpoint: 'https://graph.microsoft.com/v1.0/me'
// };
