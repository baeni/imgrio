namespace Fordele.Blazor.Backend.Interfaces
{
    public interface IUploadedFile
    {
        Guid Id { get; }

        string Extension { get; }

        DateTime CreatedAt { get; }

        DateTime ModifiedAt { get; }
    }
}
