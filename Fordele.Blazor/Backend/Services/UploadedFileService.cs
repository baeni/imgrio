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

        public IEnumerable<UploadedImage> GetUploadedImages()
        {
            var uploadedImages = new List<UploadedImage>();

            foreach (var imagePath in Directory.GetFiles(Path.Combine(DataPath, "images")))
            {
                var info = new FileInfo(imagePath);
                var split = info.Name.Split('.');

                var id = Guid.Parse(split[0]);
                var extension = split[1];
                var size = info.Length;
                var createdAt = info.CreationTime;
                var modifiedAt = info.LastWriteTime;

                uploadedImages.Add(
                    new UploadedImage(id, extension, size, createdAt, modifiedAt));
            }

            return uploadedImages;
        }

        public IEnumerable<UploadedDocument> GetUploadedDocuments()
        {
            var uploadedDocuments = new List<UploadedDocument>();

            foreach (var documentPath in Directory.GetFiles(Path.Combine(DataPath, "documents")))
            {
                var info = new FileInfo(documentPath);
                var split = info.Name.Split('.');

                var id = Guid.Parse(split[0]);
                var extension = split[1];
                var size = info.Length;
                var createdAt = info.CreationTime;
                var modifiedAt = info.LastWriteTime;

                uploadedDocuments.Add(
                    new UploadedDocument(id, extension, size, createdAt, modifiedAt));
            }

            return uploadedDocuments;
        }
    }
}
