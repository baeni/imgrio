using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace imgrio_api.Controllers
{
    /*
     * Endpoint to managa files:
     * - Get information about all users
     */

    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(AuthenticationSchemes = "FirebaseJwtPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UsersController(ImgrioDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllUsersInfo()
        {
            var set = _dbContext.Set<UserFile>();

            var count = await set.Select(x => x.Author).Distinct().CountAsync();
            var countToday = await set
                .Where(x => x.DateOfCreation.Day == DateTime.UtcNow.Day)
                .Select(x => x.Author)
                .Distinct()
                .CountAsync();

            return Ok(new
            {
                count,
                countToday
            });
        }

        [HttpGet("{userId}")]
        public IActionResult GetPermanentJwt(string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId),
                new("oid", userId.ToString()),
            };

            var dateNow = DateTime.UtcNow;

            var token = new JwtSecurityToken(
                audience: _configuration["Jwt:Audience"],
                issuer: _configuration["Jwt:Issuer"],
                notBefore: dateNow,
                expires: dateNow.AddYears(1),
                claims: claims,

                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}
