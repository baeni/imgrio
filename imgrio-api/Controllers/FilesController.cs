using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imgrio_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "SupabaseJwtPolicy")]
    [Authorize(AuthenticationSchemes = "PermanentJwtPolicy")]
    public class FilesController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;

        public FilesController(ImgrioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetUserFilesInfoAsync()
        {
            var set = _dbContext.Set<UserFile>();

            var userFilesInfo = new UserFilesInfo(
                await set.CountAsync(),
                await set.Select(x => x.DateOfCreation == DateTime.UtcNow).CountAsync());
    
            return Ok(userFilesInfo);
        }
        
        [HttpGet("{fileId}"), AllowAnonymous]
        public async Task<IActionResult> GetUserFileByIdAsync(Guid fileId)
        {
            var userFile = await _dbContext.FindAsync<UserFile>(fileId);
    
            if (userFile == null)
            {
                return NotFound("UserFile could not be found in database.");
            }
    
            return Ok(userFile);
        }
    }
}
