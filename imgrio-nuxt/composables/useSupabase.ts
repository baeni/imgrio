export const signInUser = async () => {
    const config = useRuntimeConfig();
    const supabase = useSupabaseClient();

    try {
        const { data, error } = await supabase.auth.signInWithOAuth({
            provider: "google",
            options: {
                queryParams: {
                    access_type: "offline",
                    prompt: "select_account",
                },
                redirectTo: `${config.public.siteUrl}${config.public.redirectPath}`,
            },
        });
        if (error) throw error;
    } catch (error) {
        console.log(error);
    }
};

export const signOutUser = async () => {
    const supabase = useSupabaseClient();

    try {
        const { error } = await supabase.auth.signOut();

        if (error) throw error;
    } catch (error) {
        console.log(error);
    }
};
