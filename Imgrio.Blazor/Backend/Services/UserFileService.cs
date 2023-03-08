using Imgrio.Blazor.Backend.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Identity;

namespace Imgrio.Blazor.Backend.Services
{
    public class UserFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FirestoreDb _firestoreDb;

        public UserFileService(IWebHostEnvironment webHostEnvironment, FirestoreDb firestoreDb)
        {
            _webHostEnvironment = webHostEnvironment;
            _firestoreDb = firestoreDb;

            AbsoluteFilesPath = Path.Combine("data", "files");
            FilesPath = Path.Combine(_webHostEnvironment.WebRootPath, AbsoluteFilesPath);
            if (!Path.Exists(FilesPath))
            {
                Directory.CreateDirectory(FilesPath);
            }
        }

        public string AbsoluteFilesPath { get; }
        public string FilesPath { get; }

        public async Task<Guid> CreateUserFileAsync(IdentityUser user, IFormFile file)
        {
            var id = Guid.NewGuid();
            var title = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName).Substring(1);
            var size = file.Length;
            var uploadedAt = DateTime.UtcNow;
            var uploadedBy = user.Id;
            var pathAbsolute = Path.Combine(AbsoluteFilesPath, $"{id}.{extension}");
            var path = Path.Combine(FilesPath, $"{id}.{extension}");

            #region Save file to disk
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            #endregion

            #region Save file information and referende to firestore
            var docRef = _firestoreDb.Collection("files").Document(id.ToString());
            var fields = new Dictionary<string, object>
            {
                { "title", title },
                { "extension", extension },
                { "size", size },
                { "uploadedAt", uploadedAt },
                { "uploadedBy", uploadedBy },
                { "url", pathAbsolute }
            };
            await docRef.SetAsync(fields);
            #endregion

            return id;
        }

        public async Task<IEnumerable<UserFile>> GetUserFilesAsync()
        {
            var userFiles = new List<UserFile>();

            var collectionSnapshot = await _firestoreDb.Collection("files").GetSnapshotAsync();

            foreach (var documentSnapshot in collectionSnapshot.Documents)
            {
                var title = documentSnapshot.GetValue<string>("title");
                var extension = documentSnapshot.GetValue<string>("extension");
                var size = documentSnapshot.GetValue<double>("size");
                var uploadedAt = documentSnapshot.GetValue<DateTime>("uploadedAt");
                var uploadedBy = documentSnapshot.GetValue<string>("uploadedBy");
                var url = documentSnapshot.GetValue<string>("url");

                userFiles.Add(new UserFile(Guid.Parse(documentSnapshot.Id), title, extension, size, uploadedAt, uploadedBy, url));
            }

            return userFiles;
        }

        public async Task DeleteUserFileAsync(Guid id)
        {
            var docRef = _firestoreDb.Collection("files").Document(id.ToString());
            await docRef.DeleteAsync();
        }
    }
}
