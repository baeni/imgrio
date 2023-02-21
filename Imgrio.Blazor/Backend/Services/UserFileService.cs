using Imgrio.Blazor.Backend.Models;
using Google.Cloud.Firestore;

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

        public async Task<IEnumerable<UserFile>> GetUserFiles()
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

                userFiles.Add(new UserFile(Guid.Parse(documentSnapshot.Id), title, extension, size, uploadedAt, uploadedBy));
            }

            return userFiles;
        }
    }
}
