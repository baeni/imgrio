import { PublicClientApplication, InteractionType } from '@azure/msal-browser';
import { MsalProvider } from '@azure/msal-react';

const msalConfig = {
  auth: {
    clientId: 'd9bf5b2c-ee47-40fd-8b61-cc6cd86d2582',
    authority: 'https://login.microsoftonline.com/870c73fe-c22b-46ff-87c3-b7bf53ed6125',
    redirectUri: 'http://localhost'
  }
}

const msalInstance = new PublicClientApplication(msalConfig);

export const loginRequest = {
  scopes: ['openid', 'profile'],
  prompt: 'select_account',
  interactionType: InteractionType.Popup
};

export { msalInstance, MsalProvider }