import { PublicClientApplication } from '@azure/msal-browser';

const msalConfig = {
  auth: {
    clientId: 'd9bf5b2c-ee47-40fd-8b61-cc6cd86d2582',
    authority: 'https://login.microsoftonline.com/870c73fe-c22b-46ff-87c3-b7bf53ed6125',
    redirectUri: 'http://localhost:3000',
    responseType: 'code',
    navigateToLoginRequestUrl: false
  }
};

const pca = new PublicClientApplication(msalConfig);

const loginRequest = {
  scopes: ['openid', 'profile', 'api://d9bf5b2c-ee47-40fd-8b61-cc6cd86d2582/full'],
  prompt: 'select_account'
};

export { pca, loginRequest }