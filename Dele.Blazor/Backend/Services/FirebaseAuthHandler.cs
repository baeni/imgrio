using Firebase.Auth;

namespace Dele.Blazor.Backend.Services
{
    public class FirebaseAuthHandler
    {
        public FirebaseAuthProvider FirebaseAuthProvider { get; } = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAEIqYar3BalfukLcbscsuyrkoa-o3ie_c"));
    }
}
