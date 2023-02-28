using Imgrio.Blazor.Backend.Models;
using Google.Cloud.Firestore;
using Firebase.Auth;

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

            DataPath = Path.Combine(_webHostEnvironment.WebRootPath, "data");
        }

        public string DataPath { get; }

        public async Task<IEnumerable<UserFile>> GetUserFilesAsync()
        {
            var userFiles = new List<UserFile>();

            var collectionSnapshot = await _firestoreDb.Collection("files").GetSnapshotAsync();

            foreach(var documentSnapshot in collectionSnapshot.Documents)
            {
                var title = documentSnapshot.GetValue<string>("title");
                var extension = documentSnapshot.GetValue<string>("extension");
                var size = documentSnapshot.GetValue<double>("size");
                var uploadedAt = documentSnapshot.GetValue<DateTime>("uploadedAt");
                var uploadedBy = documentSnapshot.GetValue<string>("uploadedBy");
                var base64 = documentSnapshot.GetValue<string>("base64");

                userFiles.Add(new UserFile(Guid.Parse(documentSnapshot.Id), title, extension, size, uploadedAt, uploadedBy, base64));
            }

            return userFiles;
        }

        public async Task<Guid> CreateUserFileAsync(User user, IFormFile file)
        {
            var id = Guid.NewGuid();
            var title = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName).Substring(1);
            var size = file.Length;
            var uploadedAt = DateTime.UtcNow;
            var uploadedBy = user.LocalId;
            string base64 = "";

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                base64 = Convert.ToBase64String(fileBytes);
            }

            // Save file information to firestore
            var docRef = _firestoreDb.Collection("files").Document(id.ToString());
            var fields = new Dictionary<string, object>
            {
                { "title", title },
                { "extension", extension },
                { "size", size },
                { "uploadedAt", uploadedAt },
                { "uploadedBy", uploadedBy },
                { "base64", base64 }
            };
            await docRef.SetAsync(fields);

            return id;
        }

        public async Task DeleteUserFileAsync(Guid id)
        {
            var docRef = _firestoreDb.Collection("files").Document(id.ToString());
            await docRef.DeleteAsync();
        }
    }
}
