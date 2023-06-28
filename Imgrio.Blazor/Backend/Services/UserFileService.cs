using Imgrio.Blazor.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Imgrio.Blazor.Data;
using Microsoft.EntityFrameworkCore;

namespace Imgrio.Blazor.Backend.Services
{
    public class UserFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDbContextFactory<DataContext> _dbContextFactory;

        public UserFileService(IWebHostEnvironment webHostEnvironment, IDbContextFactory<DataContext> dbContextFactory)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContextFactory = dbContextFactory;

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
            var absolutePath = Path.Combine(AbsoluteFilesPath, $"{id}.{extension}");
            var path = Path.Combine(FilesPath, $"{id}.{extension}");

            #region Save file to disk
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            #endregion

            #region Save file information and reference to database
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                await context.UserFiles.AddAsync(new UserFile(id, title, extension, size, uploadedAt, uploadedBy, absolutePath));
                context.SaveChanges();
            }
            #endregion

            return id;
        }

        public async Task<UserFile?> GetUserFileAsync(Guid id)
        {
            UserFile? userFile;

            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                userFile = await context.UserFiles.FindAsync(id);
            }

            return userFile;
        }

        public async Task<IEnumerable<UserFile>> GetUserFilesAsync(IdentityUser user)
        {
            List<UserFile> userFiles;

            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                userFiles = await context.UserFiles.Where(userFile => userFile.UploadedBy == user.Id).ToListAsync();
            }

            return userFiles;
        }

        public async Task DeleteUserFileAsync(Guid id)
        {
            UserFile? userFile;

            #region Remove file information and reference from database
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                userFile = await GetUserFileAsync(id);
                if (userFile == null)
                {
                    return;
                }

                context.UserFiles.Remove(userFile);
                context.SaveChanges();
            }
            #endregion

            var path = Path.Combine(FilesPath, $"{id}.{userFile.Extension}");

            #region Delete file from disk
            File.Delete(path);
            #endregion
        }
    }
}
