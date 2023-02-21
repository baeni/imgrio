using Firebase.Auth;

namespace Imgrio.Blazor.Backend.Services
{
    public class FirebaseAuthHandler
    {
        public FirebaseAuthProvider FirebaseAuthProvider { get; } = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC-a7ssy-0Wx5Vf1OVvu1KtSO5MJ8t-CD0"));
    }
}
