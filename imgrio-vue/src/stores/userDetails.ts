import { ref } from 'vue';
import { defineStore } from 'pinia';

import { msalInstance } from '@/authConfig';
import {
  AuthCodeMSALBrowserAuthenticationProvider,
  type AuthCodeMSALBrowserAuthenticationProviderOptions
} from '@microsoft/microsoft-graph-client/authProviders/authCodeMsalBrowser';
import { InteractionType } from '@azure/msal-browser';
import { Client } from '@microsoft/microsoft-graph-client';

export const useUserDetailsStore = defineStore('userDetaisStore', () => {
  const userDetails = ref();

  async function fetchUserDetails() {
    const account = msalInstance.getActiveAccount() ?? msalInstance.getAllAccounts()[0];

    const options: AuthCodeMSALBrowserAuthenticationProviderOptions = {
      account: account,
      interactionType: InteractionType.Redirect,
      scopes: ['user.read']
    };

    const client = Client.initWithMiddleware({
      authProvider: new AuthCodeMSALBrowserAuthenticationProvider(msalInstance, options)
    });

    userDetails.value = await client.api('/me').get();
  }

  return { fetchUserDetails, userDetails };
});
