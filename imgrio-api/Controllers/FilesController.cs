using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet;
using Renci.SshNet.Async;

namespace imgrio_api.Controllers
{
    /*
     * Endpoint to manage files:
     * - Get information about all files
     * - Get a single file by its ID
     * - Get multiple files by a UserID
     * - Post a file by a UserIdD
     * - Delete a single file by its ID
     * - Delete all files by a UserID
     */

    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FilesController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public FilesController(ImgrioDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllFilesInfoAsync()
        {
            var set = _dbContext.Set<UploadedFile>();

            var count = await set.CountAsync();
            var countToday = await set
                .Select(x => x.UploadedAt.Day == DateTime.UtcNow.Day)
                .CountAsync();

            return Ok(new {
                count,
                countToday
            });
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetFileInfoByIdAsync(Guid id)
        {
            var uploadedFile = await _dbContext.FindAsync<UploadedFile>(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            return Ok(uploadedFile);
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetFilesInfoByUserIdAsync(Guid userId)
        {
            var uploadedFiles = await _dbContext.Set<UploadedFile>()
                .Where(x => x.UploadedBy == userId).ToArrayAsync();

            return Ok(uploadedFiles);
        }

        [HttpPost("users/{userId}")]
        public async Task<IActionResult> PostFileByUserIdAsync(Guid userId, [FromForm] IFormFile file)
        {
            var uploadedFile = new UploadedFile(
                Guid.NewGuid(),
                file.FileName,
                file.ContentType,
                file.Length,
                DateTime.UtcNow,
                userId,
                false,
                null);

            if (uploadedFile.IsExternal)
            {
                #region save to user server
                // TODO
                throw new NotImplementedException("Self hosting is not yet implemented.");
                #endregion
            }
            else
            {
                #region save to imgrio server
                using var client = new SftpClient(
                        _configuration.GetValue<string>("UploadServer:Host")!,
                        _configuration.GetValue<string>("UploadServer:User")!,
                        _configuration.GetValue<string>("UploadServer:Password")!);
                client.Connect();

                var path = $"{_configuration.GetValue<string>("UploadServer:FilePath")!}{uploadedFile.UploadedBy}";
                if (!client.Exists(path))
                {
                    client.CreateDirectory(path);
                }
                await client.UploadAsync(file.OpenReadStream(), $"{path}/{uploadedFile.NameWithExtension}");

                client.Disconnect();
                #endregion
            }

            #region save to database
            await _dbContext.AddAsync(uploadedFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            return Ok($"Successfully posted file '{uploadedFile.Name}' for user with id: {userId}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileByIdAsync(Guid id)
        {
            var uploadedFile = await _dbContext.FindAsync<UploadedFile>(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            #region delete from database
            _dbContext.Remove(uploadedFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            if (uploadedFile.IsExternal)
            {
                #region delete from user server
                // TODO
                throw new NotImplementedException("Self hosting is not yet implemented.");
                #endregion
            }
            else
            {
                #region delete from imgrio server
                using var client = new SftpClient(
                    _configuration.GetValue<string>("UploadServer:Host")!,
                    _configuration.GetValue<string>("UploadServer:User")!,
                    _configuration.GetValue<string>("UploadServer:Password")!);
                client.Connect();

                var path = $"{_configuration.GetValue<string>("UploadServer:FilePath")!}{uploadedFile.UploadedBy}";
                client.DeleteFile($"{path}/{uploadedFile.NameWithExtension}");

                client.Disconnect();
                #endregion
            }

            return Ok($"Deleted file with id: {id}");
        }

       [HttpDelete("users/{userId}")]
        public async Task<IActionResult> DeleteFilesByUserIdAsync(Guid userId)
        {
            var uploadedFiles = await _dbContext.Set<UploadedFile>().Where(x => x.UploadedBy == userId).ToArrayAsync();

            if (uploadedFiles == null || uploadedFiles.Length <= 0)
            {
                return NotFound();
            }

            #region delete from database
            _dbContext.RemoveRange(uploadedFiles);
            await _dbContext.SaveChangesAsync();
            #endregion

            foreach (var uploadedFile in uploadedFiles)
            {
                if (uploadedFile.IsExternal)
                {
                    #region delete from user server
                    // TODO
                    throw new NotImplementedException("Self hosting is not yet implemented.");
                    #endregion
                }
                else
                {
                    #region delete from imgrio server
                    using var client = new SftpClient(
                        _configuration.GetValue<string>("UploadServer:Host")!,
                        _configuration.GetValue<string>("UploadServer:User")!,
                        _configuration.GetValue<string>("UploadServer:Password")!);
                    client.Connect();

                    var path = $"{_configuration.GetValue<string>("UploadServer:FilePath")!}{uploadedFile.UploadedBy}";
                    client.DeleteFile($"{path}/{uploadedFile.NameWithExtension}");

                    client.Disconnect();
                    #endregion
                }
            }

            return Ok($"Successfully deleted files for user with id: {userId}");
        }
    }
}
