using Microsoft.Extensions.Configuration;
using nClam;
using System.Net.Sockets;

namespace imgrio_api.Extensions
{
    public static class IFormFileExtensions
    {
        public static bool IsValidMimeType(this IFormFile file)
        {
            var validMimeTypes = new string[] {
                "image/",
                "text/plain",
                "application/pdf",
                "application/msword",
                "application/vnd.openxmlformats-officedocument."
            };

            var fileType = file.ContentType;
            if (validMimeTypes.Where(fileType.StartsWith).ToArray().Length <= 0)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> IsSafe(this IFormFile file)
        {
            try
            {
                var clam = new ClamClient("localhost", 3310);
                var response = await clam.SendAndScanFileAsync(file.OpenReadStream());

                switch (response.Result)
                {
                    case ClamScanResults.Clean:
                        return true;
                    case ClamScanResults.VirusDetected:
                    case ClamScanResults.Unknown:
                    case ClamScanResults.Error:
                    default:
                        return false;
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
