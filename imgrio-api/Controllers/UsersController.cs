using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imgrio_api.Controllers
{
    /*
     * Endpoint to managa files:
     * - Get information about all users
     */

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;

        public UsersController(ImgrioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersInfo()
        {
            var set = _dbContext.Set<UserFile>();

            var count = await set.Select(x => x.UploadedBy).Distinct().CountAsync();
            var countToday = await set
                .Where(x => x.UploadedAt.Day == DateTime.UtcNow.Day)
                .Select(x => x.UploadedBy)
                .Distinct()
                .CountAsync();

            return Ok(new
            {
                count,
                countToday
            });
        }
    }
}
