using Fordele.Blazor.Backend.Models;
using Google.Cloud.Firestore;

namespace Fordele.Blazor.Backend.Services
{
    public class UserFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FirestoreDb _firestoreDb;

        public UserFileService(IWebHostEnvironment webHostEnvironment, FirestoreDb firestoreDb)
        {
            _webHostEnvironment = webHostEnvironment;
            _firestoreDb = firestoreDb;
            DataPath = Path.Combine(_webHostEnvironment.WebRootPath, "data");
        }

        public string DataPath { get; }

        public async Task<IEnumerable<UserFile>> GetUserFiles()
        {
            var userFiles = new List<UserFile>();

            var collectionSnapshot = await _firestoreDb.Collection("uploads").GetSnapshotAsync();

            foreach(var documentSnapshot in collectionSnapshot.Documents)
            {
                var title = documentSnapshot.GetValue<string>("Title");
                var extension = documentSnapshot.GetValue<string>("Extension");
                var size = documentSnapshot.GetValue<double>("Size");
                var uploadedAt = documentSnapshot.GetValue<DateTime>("UploadedAt");
                var uploadedBy = documentSnapshot.GetValue<string>("UploadedBy");

                userFiles.Add(new UserFile(Guid.Parse(documentSnapshot.Id), title, extension, size, uploadedAt, uploadedBy));
            }

            return userFiles;
        }

        //public IEnumerable<UploadedImage> GetUploadedImages()
        //{
        //    var uploadedImages = new List<UploadedImage>();

        //    foreach (var imagePath in Directory.GetFiles(Path.Combine(DataPath, "images")))
        //    {
        //        var info = new FileInfo(imagePath);
        //        var split = info.Name.Split('.');

        //        var id = Guid.Parse(split[0]);
        //        var extension = split[1];
        //        var size = info.Length;
        //        var createdAt = info.CreationTime;
        //        var modifiedAt = info.LastWriteTime;

        //        uploadedImages.Add(
        //            new UploadedImage(id, extension, size, createdAt, modifiedAt));
        //    }

        //    return uploadedImages;
        //}

        //public IEnumerable<UserFile> GetUploadedDocuments()
        //{
        //    var uploadedDocuments = new List<UserFile>();

        //    foreach (var documentPath in Directory.GetFiles(Path.Combine(DataPath, "documents")))
        //    {
        //        var info = new FileInfo(documentPath);
        //        var split = info.Name.Split('.');

        //        var id = Guid.Parse(split[0]);
        //        var extension = split[1];
        //        var size = info.Length;
        //        var createdAt = info.CreationTime;
        //        var modifiedAt = info.LastWriteTime;

        //        uploadedDocuments.Add(
        //            new UserFile(id, extension, size, createdAt, modifiedAt));
        //    }

        //    return uploadedDocuments;
        //}
    }
}
