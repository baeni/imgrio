using imgrio_api.Data;
using imgrio_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace imgrio_api.Controllers
{
    /*
     * Endpoint to manage files:
     * - Get information about all users
     */

    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "SupabaseJwtPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UsersController(ImgrioDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSettingsByUserIdAsync(Guid userId)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (sub == null || !sub.Equals(userId.ToString()))
            {
                return Unauthorized("Cannot access other users ressources.");
            }

            var userSettings = await _dbContext.FindAsync<UserSettings>(userId);

            if (userSettings == null)
            {
                return NotFound();
            }

            return Ok(userSettings);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutSettingsByUserIdAsync(Guid userId, UserSettings userSettings)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (sub == null || !sub.Equals(userId.ToString()))
            {
                return Unauthorized("Cannot access other users ressources.");
            }

            await _dbContext.AddAsync(userSettings);
            await _dbContext.SaveChangesAsync();

            return Ok(userSettings);
        }

        [HttpGet("{userId}")]
        public IActionResult GetPermanentJwt(Guid userId)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (sub == null || !sub.Equals(userId.ToString()))
            {
                return Unauthorized("Cannot access other users ressources.");
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["PermanentJwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            };

            var dateNow = DateTime.UtcNow;

            var token = new JwtSecurityToken(
                audience: _configuration["PermanentJwt:Audience"],
                issuer: _configuration["PermanentJwt:Issuer"],
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
