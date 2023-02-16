using Firebase.Auth;

namespace Fordele.Blazor.Backend.Services
{
    public class FirebaseAuthHandler
    {
        public FirebaseAuthProvider FirebaseAuthProvider { get; } = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAvgwBVchyVPYw44j6PpcfJl6W6bo4bTaE"));
    }
}
