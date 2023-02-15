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
                var fileInfo = new FileInfo(filePath);
                var split = fileInfo.Name.Split('.');

                var id = Guid.Parse(split[0]);
                var extension = split[1];
                var size = Math.Round(fileInfo.Length / 1000000d, 2);
                var createdAt = fileInfo.CreationTime;
                var modifiedAt = fileInfo.LastWriteTime;

                var uploadedFile = new UploadedFile(id, extension, size, createdAt, modifiedAt);
                uploadedFiles.Add(uploadedFile);
            }

            return uploadedFiles;
        }

        public IEnumerable<IUploadedFile> GetUploadedImages()
        {
            return GetUploadedFiles().Where(uploadedFile =>
                uploadedFile.Extension == "png" || uploadedFile.Extension == "jpg" || uploadedFile.Extension == "jpeg");
        }

        public IEnumerable<IUploadedFile> GetUploadedDocuments()
        {
            return GetUploadedFiles().Where(uploadedFile =>
                uploadedFile.Extension == "txt" || uploadedFile.Extension == "zip" || uploadedFile.Extension == "jar");
        }
    }
}
