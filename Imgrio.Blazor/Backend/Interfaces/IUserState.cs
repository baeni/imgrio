using Firebase.Auth;

namespace Imgrio.Blazor.Backend.Interfaces
{
    public interface IUserState
    {
        User? FirebaseUser { get; set; }

        bool IsAuthenticated { get; }
        
        string Id { get; }
        
        string Email { get; }
        
        string Name { get; }
        
        string Role { get; }

    }
}
