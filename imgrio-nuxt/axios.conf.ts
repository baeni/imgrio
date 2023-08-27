import axios from "axios";
import { getAuth } from "firebase/auth";

const apiClient = axios.create({
  baseURL: "https://api.imgrio.com",
});

apiClient.interceptors.request.use(async (config) => {
  const currentUser = getAuth().currentUser;

  if (!currentUser) {
    console.log("Nobody");
    return config;
  }

  try {
    const token = await currentUser.getIdToken();

    config.headers.Authorization = `Bearer ${token}`;
    return config;
  } catch (error) {
    console.error(error);
    return Promise.reject(error);
  }
});

export { apiClient };
