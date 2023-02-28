namespace Imgrio.Blazor.Backend.Interfaces
{
    public interface IUserFile
    {
        Guid Id { get; }

        string Extension { get; }

        string Title { get; }

        double Size { get; }

        DateTime UploadedAt { get; }

        string UploadedBy { get; }

        string Base64 { get; }
    }
}
