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
                >= 1000000000 => $"{size / 1000000000} GB",
                >= 1000000 => $"{size / 1000000} MB",
                >= 1000 => $"{size / 1000} KB",
                _ => $"{size} B",
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
