import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://api.imgrio.com",
});

apiClient.interceptors.request.use(async (config) => {
  const supabase = useSupabaseClient();

  const token = (await supabase.auth.getSession()).data.session?.access_token;

  if (!token) {
    return config;
  }

  try {
    config.headers.Authorization = `Bearer ${token}`;
    return config;
  } catch (error) {
    console.error(error);
    return Promise.reject(error);
  }
});

export { apiClient };
