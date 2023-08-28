export const signInUser = async () => {
  const supabase = useSupabaseClient();

  try {
    const { data, error } = await supabase.auth.signInWithOAuth({
      provider: "google",
      options: {
        queryParams: {
          access_type: "offline",
          prompt: "select_account",
        },
        redirectTo: process.env.SITE_URL,
      },
    });
    if (error) throw error;
  } catch (error) {
    console.log(error);
  }
};

export const signOutUser = async () => {
  const supabase = useSupabaseClient();

  const { error } = await supabase.auth.signOut();
};
