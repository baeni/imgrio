using HeyRed.Mime;

namespace imgrio_api.Models
{
    public class UserFile
    {
        public UserFile(
            Guid id,
            string title,
            string type,
            long size,
            DateTime uploadedAt,
            Guid uploadedBy,
            string url,
            string directUrl,
            bool isSelfHosted)
        {
            Id = id;
            Title = title;
            Type = type;
            Size = size;
            UploadedAt = uploadedAt;
            UploadedBy = uploadedBy;
            Url = url;
            DirectUrl = directUrl;
            IsSelfHosted = isSelfHosted;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; }
        public long Size { get; private set; }
        public DateTime UploadedAt { get; private set; }
        public Guid UploadedBy { get; private set; }
        public string Url { get; private set; }
        public string DirectUrl { get; private set; }
        public bool IsSelfHosted { get; private set; }

        public override string ToString()
        {
            return $"{Id}.{MimeTypesMap.GetExtension(Type)}";
        }
    }
}
