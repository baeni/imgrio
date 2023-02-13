using Fordele.Blazor.Backend.Interfaces;
using Fordele.Blazor.Backend.Models;

namespace Fordele.Blazor.Backend.Services
{
    public class UploadedFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadedFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            DataPath = Path.Combine(_webHostEnvironment.WebRootPath, "data");
        }

        public string DataPath { get; }

        public IEnumerable<IUploadedFile> GetUploadedFiles()
        {
            var uploadedFiles = new List<IUploadedFile>();

            foreach (var filePath in Directory.GetFiles(DataPath))
            {
                var fileName = Path.GetFileName(filePath);
                var split = fileName.Split('.');

                var id = Guid.Parse(split[0]);
                var extension = split[1];
                var createdAt = File.GetCreationTimeUtc(filePath);
                var modifiedAt = File.GetLastWriteTimeUtc(filePath);

                var uploadedFile = new UploadedFile(id, extension, createdAt, modifiedAt);
                uploadedFiles.Add(uploadedFile);
            }

            return uploadedFiles;
        }
    }
}
