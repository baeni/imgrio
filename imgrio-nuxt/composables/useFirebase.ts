// https://firebase.google.com/docs/auth/web/start

import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
  signOut,
  onAuthStateChanged,
} from "firebase/auth";
import { useRouter } from "vue-router";

export const signInUser = async () => {
  const auth = getAuth();
  auth.useDeviceLanguage();

  const provider = new GoogleAuthProvider();
  // provider.addScope("https://www.googleapis.com/auth/contacts.readonly");
  provider.setCustomParameters({
    prompt: "select_account",
  });

  signInWithPopup(auth, provider)
    .then((result) => {
      const credential = GoogleAuthProvider.credentialFromResult(result);
      if (!credential) {
        throw new Error("Credentials are not present!");
      }

      const token = credential.accessToken;
      const user = result.user;
      // IdP data available using getAdditionalUserInfo(result)
    })
    .catch((error) => {
      const errorCode = error.code;
      const errorMessage = error.message;
      const email = error.customData.email;
      const credential = GoogleAuthProvider.credentialFromError(error);
    });
};

export const signOutUser = async () => {
  const auth = getAuth();

  signOut(auth);
};

export const initUser = async () => {
  const auth = getAuth();
  const router = useRouter();

  onAuthStateChanged(auth, (user) => {
    if (user) {
      router.push("/dashboard/files");
    } else {
      router.push("/");
    }
  });
};
