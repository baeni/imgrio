import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";
import { getFirestore } from "firebase/firestore";
// import { getAnalytics } from "firebase/analytics";

export default defineNuxtPlugin((nuxtApp) => {
  // const config = useRuntimeConfig();

  const firebaseConfig = {
    apiKey: "AIzaSyD775Ncbcyf98Qmqo7F7WE_GMpJIRsLxiY",
    authDomain: "imgrio-b1ddc.firebaseapp.com",
    projectId: "imgrio-b1ddc",
    appId: "1:469817125060:web:81ca004d19dd661e0e4191",
    storageBucket: "imgrio-b1ddc.appspot.com",
    messagingSenderId: "469817125060",
    measurementId: "G-WNEXEH32BG",
  };

  const app = initializeApp(firebaseConfig);

  initUser();

  // const analytics = getAnalytics(app);
  const auth = getAuth(app);
  const firestore = getFirestore(app);

  nuxtApp.vueApp.provide("auth", auth);
  nuxtApp.provide("auth", auth);

  nuxtApp.vueApp.provide("firestore", firestore);
  nuxtApp.provide("firestore", firestore);
});
