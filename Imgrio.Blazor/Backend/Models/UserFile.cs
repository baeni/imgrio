using Imgrio.Blazor.Backend.Interfaces;

namespace Imgrio.Blazor.Backend.Models
{
    public class UserFile : IUserFile
    {
        public UserFile(Guid id, string title, string extension, double size, DateTime uploadedAt, string uploadedBy)
        {
            Id = id;
            Title = title;
            Extension = extension;
            Size = size;
            UploadedAt = uploadedAt;
            UploadedBy = uploadedBy;
        }

        public Guid Id { get; }

        public string Extension { get; }

        public string FileName => $"{Id}.{Extension}";

        public string FileUrl => "https://imgrio.azurewebsites.net/" + Path.Combine("data", $"{Id}.{Extension}");

        public string Title { get; }

        public double Size { get; }

        public DateTime UploadedAt { get; }

        public string UploadedBy { get; }
    }
}
