using Fordele.Blazor.Backend.Interfaces;

namespace Fordele.Blazor.Backend.Models
{
    public class UploadedFile : IUploadedFile
    {
        public UploadedFile(Guid id, string extension, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Extension = extension;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }

        public Guid Id { get; }

        public string Extension { get; }

        public DateTime CreatedAt { get; }

        public DateTime ModifiedAt { get; }

        public string FancyCreatedOrModified => ModifiedAt.Date == CreatedAt.Date
                                                    ? CreatedAt.Date == DateTime.UtcNow.Date
                                                        ? "Heute hochgeladen"
                                                        : $"Hochgeladen am {CreatedAt.ToString("dd.MM.yyyy")}"
                                                    : CreatedAt.Date == DateTime.UtcNow.Date
                                                        ? "Heute zuletzt verändert"
                                                        : $"Zuletzt verändert am {CreatedAt.ToString("dd.MM.yyyy")}";
    }
}
