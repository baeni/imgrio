export default async function () {
  const user = useCurrentUser();

  console.log("user: " + user);

  if (!user) {
    return navigateTo("/");
  }
}
