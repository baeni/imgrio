using HeyRed.Mime;
using System.ComponentModel.DataAnnotations.Schema;

namespace imgrio_api.Models
{
    public class UploadedFile
    {
        public UploadedFile(
            Guid id,
            string name,
            string type,
            long size,
            DateTime uploadedAt,
            Guid uploadedBy,
            bool isExternal,
            string? externalUri)
        {
            Id = id;
            Name = name;
            Type = type;
            Size = size;
            UploadedAt = uploadedAt;
            UploadedBy = uploadedBy;
            IsExternal = isExternal;
            ExternalUri = externalUri;

            NameWithExtension = $"{Id}.{MimeTypesMap.GetExtension(Type)}";
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public long Size { get; private set; }
        public DateTime UploadedAt { get; private set; }
        public Guid UploadedBy { get; private set; }
        public bool IsExternal { get; private set; }
        public string? ExternalUri { get; set; }

        [NotMapped]
        public string NameWithExtension { get; private set; }
    }
}
