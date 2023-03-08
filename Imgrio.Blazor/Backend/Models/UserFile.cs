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

        public Guid Id { get; private set; }

        public string Extension { get; private set; }

        public string Title { get; private set; }

        public double Size { get; private set; }

        public DateTime UploadedAt { get; private set; }

        public string UploadedBy { get; private set; }

        public string Url { get; private set; }
    }
}
