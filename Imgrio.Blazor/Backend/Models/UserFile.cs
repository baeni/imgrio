using Imgrio.Blazor.Backend.Interfaces;

namespace Imgrio.Blazor.Backend.Models
{
    public class UserFile : IUserFile
    {
        public UserFile(Guid id, string title, string extension, double size, DateTime uploadedAt, string uploadedBy, string url)
        {
            Id = id;
            Title = title;
            Extension = extension;
            Size = size;
            UploadedAt = uploadedAt;
            UploadedBy = uploadedBy;
            Url = url;
        }

        public Guid Id { get; }

        public string Extension { get; }

        public string Title { get; }

        public double Size { get; }

        public DateTime UploadedAt { get; }

        public string UploadedBy { get; }

        public string Url { get; }
    }
}
