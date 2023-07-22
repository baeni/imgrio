import axios from 'axios';

import { msalInstance, loginRequest } from './authConfig';

const apiClient = axios.create({
  baseURL: 'http://api.imgrio.com'
});

apiClient.interceptors.request.use(async (config) => {
  const activeAccount = msalInstance.getActiveAccount();
  const accounts = msalInstance.getAllAccounts();

  if (!activeAccount && accounts.length === 0) {
    return config;
  }

  try {
    const token = await msalInstance.acquireTokenSilent({
      ...loginRequest,
      account: activeAccount || accounts[0]
    });
    config.headers.Authorization = `Bearer ${token.idToken}`;
  } catch (error) {
    console.error();
  }

  return config;
});

export { apiClient };
