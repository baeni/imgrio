// https://firebase.google.com/docs/auth/web/start
import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
  signOut,
  onAuthStateChanged,
} from "firebase/auth";

export const signInUser = async () => {
  const auth = getAuth();
  auth.useDeviceLanguage();

  const provider = new GoogleAuthProvider();
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
  const userRef = useCurrentUser();
  userRef.value = auth.currentUser;

  onAuthStateChanged(auth, () => {
    if (auth.currentUser) {
      console.log("auth state changed -> authed");
    } else {
      console.log("auth state changed -> unauthed");
    }

    userRef.value = auth.currentUser;
  });
};
