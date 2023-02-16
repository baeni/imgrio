using Fordele.Blazor.Backend.Interfaces;

namespace Fordele.Blazor.Backend.Utils
{
    public static class ExtensionMethods
    {
        public static string ToFormattedSizeString(this IUploadedFile uploadedFile)
        {
            var size = uploadedFile.Size;

            return size switch
            {
                >= 1000000000 => $"{Math.Round(size / 1000000000, 2)} GB",
                >= 1000000 => $"{Math.Round(size / 1000000, 2)} MB",
                >= 1000 => $"{Math.Round(size / 1000, 2)} KB",
                _ => $"{Math.Round(size, 2)} B",
            };
        }

        public static string ToFancyCreatedOrModifiedString(this IUploadedFile uploadedFile)
        {
            string? str;

            var createdDate = uploadedFile.CreatedAt.Date;
            var modifiedDate = uploadedFile.ModifiedAt.Date;
            var nowDate = DateTime.UtcNow.Date;

            if (modifiedDate == createdDate)
            {
                if (createdDate == nowDate) { str = "Heute hochgeladen"; }
                else { str = $"Hochgeladen am {createdDate.ToString("dd.MM.yyyy")}"; }
            }
            else
            {
                if (modifiedDate == nowDate) { str = "Heute zuletzt verändert"; }
                else { str = $"Zuletzt verändert am {modifiedDate.ToString("dd.MM.yyyy")}"; }
            }

            return str;
        }
    }
}
