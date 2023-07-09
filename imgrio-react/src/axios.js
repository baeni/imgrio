import axios from 'axios';

import { pca, loginRequest } from './authConfig';

const apiClient = axios.create({
  baseURL: 'http://localhost:8080'
});

apiClient.interceptors.request.use(async (config) => {
  const activeAccount = pca.getActiveAccount();
  const accounts = pca.getAllAccounts();

  if (!activeAccount && accounts.length === 0) {
    return config; 
  }

  try {
    const token = await pca.acquireTokenSilent({...loginRequest, account: activeAccount || accounts[0]});
    config.headers.Authorization = `Bearer ${token.idToken}`;
  } catch {
    
  }

  return config;
});

export { apiClient };