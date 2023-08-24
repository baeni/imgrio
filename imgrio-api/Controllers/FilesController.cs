using HeyRed.Mime;
using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [Authorize(AuthenticationSchemes = "FirebaseJwtPolicy")]
    [Authorize(AuthenticationSchemes = "PermanentJwtPolicy")]
    public class FilesController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;

        public FilesController(ImgrioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllFilesInfoAsync()
        {
            var set = _dbContext.Set<UserFile>();

            var count = await set.CountAsync();
            var countToday = await set
                .Select(x => x.DateOfCreation.Day == DateTime.UtcNow.Day)
                .CountAsync();

            return Ok(new {
                count,
                countToday
            });
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetFileByIdAsync(Guid id)
        {
            var uploadedFile = await _dbContext.FindAsync<UserFile>(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            return Ok(uploadedFile);
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetFilesByUserIdAsync(string userId)
        {
            //var sub = User.FindFirstValue("sub");
            //if (sub == null || !sub.Equals(userId))
            //{
            //    return Unauthorized("Cannot access other users ressources. sub is " + User);
            //}

            var uploadedFiles = await _dbContext.Set<UserFile>()
                .Where(x => x.Author == userId).ToArrayAsync();

            return Ok(uploadedFiles);
        }

        [HttpPost("users/{userId}")]
        public async Task<IActionResult> PostFileByUserIdAsync(string userId, [FromForm] IFormFile file)
        {
            //var sub = User.FindFirstValue("sub");
            //if (sub == null || !sub.Equals(userId))
            //{
            //    return Unauthorized("Cannot access other users ressources.");
            //}

            var fileType = file.ContentType;
            var fileId = Guid.NewGuid();
            var isUserSelfHosting = false;

            var uploadedFile = new UserFile(
                fileId,
                userId,
                Path.GetFileNameWithoutExtension(file.FileName),
                fileType,
                file.Length,
                isUserSelfHosting ? "<notYetImplemented>" : $"https://data.imgrio.com/{userId}/{fileId}.{MimeTypesMap.GetExtension(fileType)}",
                isUserSelfHosting,
                DateTime.UtcNow);

            if (uploadedFile.IsSelfHosted)
            {
                #region save to user server
                // TODO
                throw new NotImplementedException("Self hosting is not yet implemented.");
                #endregion
            }
            else
            {
                #region save to imgrio server
                var path = $"./data/{uploadedFile.Author}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using var stream = new FileStream($"{path}/{uploadedFile}", FileMode.Create);
                await file.CopyToAsync(stream);
                #endregion
            }

            #region save to database
            await _dbContext.AddAsync(uploadedFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            return Ok(new { userFile = uploadedFile , url = $"https://imgrio.com/v/{uploadedFile.Id}"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileByIdAsync(Guid id)
        {
            var uploadedFile = await _dbContext.FindAsync<UserFile>(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            //var sub = User.FindFirstValue("sub");
            //if (sub == null || !sub.Equals(uploadedFile.Author))
            //{
            //    return Unauthorized("Cannot access other users ressources.");
            //}

            #region delete from database
            _dbContext.Remove(uploadedFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            if (uploadedFile.IsSelfHosted)
            {
                #region delete from user server
                // TODO
                throw new NotImplementedException("Self hosting is not yet implemented.");
                #endregion
            }
            else
            {
                #region delete from imgrio server
                var path = $"./data/{uploadedFile.Author}/{uploadedFile}";
                if (!System.IO.File.Exists(path))
                {
                    return NotFound($"Could not find file with id: {id}");
                }
                System.IO.File.Delete(path);
                #endregion
            }

            return Ok($"Deleted file with id: {id}");
        }

        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> DeleteFilesByUserIdAsync(string userId)
        {
            //var sub = User.FindFirstValue("sub");
            //if (sub == null || !sub.Equals(userId))
            //{
            //    return Unauthorized("Cannot access other users ressources.");
            //}

            var uploadedFiles = await _dbContext.Set<UserFile>().Where(x => x.Author == userId).ToArrayAsync();

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
                if (uploadedFile.IsSelfHosted)
                {
                    #region delete from user server
                    // TODO
                    throw new NotImplementedException("Self hosting is not yet implemented.");
                    #endregion
                }
                else
                {
                    #region delete from imgrio server
                    var path = $"./data/{uploadedFile.Author}/{uploadedFile}";
                    if (!System.IO.File.Exists(path))
                    {
                        return NotFound($"Could not find file with id: {uploadedFile.Id}");
                    }
                    System.IO.File.Delete(path);
                    #endregion
                }
            }

            return Ok($"Successfully deleted files for user with id: {userId}");
        }
    }
}
