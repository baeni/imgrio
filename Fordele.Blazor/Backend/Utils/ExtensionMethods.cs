using Fordele.Blazor.Backend.Interfaces;

namespace Fordele.Blazor.Backend.Utils
{
    public static class ExtensionMethods
    {
        public static string ToFormattedSizeString(this IUserFile uploadedFile)
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
    }
}
