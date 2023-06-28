using Imgrio.Blazor.Backend.Interfaces;

namespace Imgrio.Blazor.Backend.Utils
{
    public static class ExtensionMethods
    {
        private const int Second = 1;
        const int Minute = 60 * Second;
        const int Hour = 60 * Minute;
        const int Day = 24 * Hour;
        const int Month = 30 * Day;

        public static string ToRelativeDateString(this DateTime dateTime)
        {
            var timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - dateTime.Ticks);
            var seconds = timeSpan.TotalSeconds;

            switch (seconds)
            {
                case < 1 * Minute:
                    return "Gerade eben";

                case < 2 * Minute:
                    return $"Vor einer Minute";

                case < 1 * Hour:
                    return $"Vor {timeSpan.Minutes} Minuten";

                case < 2 * Hour:
                    return $"Vor einer Stunde";

                case < 1 * Day:
                    return $"Vor {timeSpan.Hours} Stunden";

                case < 2 * Day:
                    return $"Vor einem Tag";

                case < 1 * Month:
                    return $"Vor {timeSpan.Days} Tagen";

                case < 2 * Month:
                    return $"Vor einem Monat";

                default:
                    return $"Vor {timeSpan.Days / 30} Monaten";
            }
        }

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
