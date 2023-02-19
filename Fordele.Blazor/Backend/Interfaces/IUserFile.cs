namespace Fordele.Blazor.Backend.Interfaces
{
    public interface IUserFile
    {
        Guid Id { get; }

        string Extension { get; }

        string FileName { get; }

        string FileUrl { get; }

        string Title { get; }

        double Size { get; }

        DateTime UploadedAt { get; }

        string UploadedBy { get; }
    }
}
