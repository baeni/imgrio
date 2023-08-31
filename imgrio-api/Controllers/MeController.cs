using HeyRed.Mime;
using imgrio_api.Data;
using imgrio_api.Extensions;
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
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "SupabaseJwtPolicy")]
    public class MeController : ControllerBase
    {
        private readonly ImgrioDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public MeController(ImgrioDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyUserDetailsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("files")]
        public async Task<IActionResult> GetMyFilesAsync()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var userId = Guid.Parse(sub);

            var userFiles = await _dbContext.UserFiles
                .Where(userFile => userFile.Author == userId).ToArrayAsync();

            return Ok(userFiles);
        }

        [HttpPost("files")]
        [Authorize(AuthenticationSchemes = "PermanentJwtPolicy")]
        public async Task<IActionResult> PostMyUserFileAsync([FromForm] IFormFile file)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            if (!file.IsValidMimeType())
            {
                return StatusCode(403, "Unsupported file type.");
            }

            //if (!(await file.IsSafe()))
            //{
            //    return StatusCode(403, "The file appears to be unsafe.");
            //}

            var userId = Guid.Parse(sub);

            var userFileId = Guid.NewGuid();
            var fileMimeType = file.ContentType;
            var userFile = new UserFile(
                userFileId,
                userId,
                Path.GetFileNameWithoutExtension(file.FileName),
                fileMimeType,
                file.Length,
                $"https://data.imgrio.com/{userId}/{userFileId}.{MimeTypesMap.GetExtension(fileMimeType)}",
                DateTime.UtcNow);

            #region save to imgrio server
            var path = $"./data/{userFile.Author}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using var stream = new FileStream($"{path}/{userFile}", FileMode.Create);
            await file.CopyToAsync(stream);
            #endregion

            #region save to database
            await _dbContext.AddAsync(userFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            return Ok(new { userFile, url = $"https://imgrio.com/v/{userFileId}" });
        }

        [HttpDelete("files/{userFileId}")]
        public async Task<IActionResult> DeleteMyUserFileByIdAsync(Guid userFileId)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var userId = Guid.Parse(sub);

            var userFile = await _dbContext.UserFiles.FindAsync(userFileId);
            if (userFile == null)
            {
                return NotFound("UserFile could not be found in database.");
            }
            if (userFile.Author != userId)
            {
                return Unauthorized("Sub and Author do not match.");
            }

            #region delete from database
            _dbContext.Remove(userFile);
            await _dbContext.SaveChangesAsync();
            #endregion

            #region delete from imgrio server
            var path = $"./data/{userFile.Author}/{userFile}";
            if (!System.IO.File.Exists(path))
            {
                return NotFound("UserFile could not be found on imgrio server.");
            }
            System.IO.File.Delete(path);
            #endregion

            return Ok("Successfully deleted UserFile.");
        }

        [HttpGet("settings")]
        public async Task<IActionResult> GetMyUserSettingsAsync()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var userId = Guid.Parse(sub);

            var userSettings = await _dbContext.UserSettings
                .Where(userSetting => userSetting.UserId == userId).ToArrayAsync();

            return Ok(userSettings);
        }

        [HttpPut("settings")]
        public async Task<IActionResult> PutMyUserSettingAsync(string key, string value)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var userId = Guid.Parse(sub);

            var userSetting = (await _dbContext.UserSettings
                .Where(userSetting => userSetting.UserId == userId && userSetting.Key == key).ToArrayAsync())[0];

            if (userSetting == null)
            {
                await _dbContext.AddAsync(new UserSetting(Guid.NewGuid(), userId, key, value));
            }
            else
            {
                _dbContext.Attach(userSetting);
                userSetting.Value = value;
            }
            await _dbContext.SaveChangesAsync();

            return Ok(userSetting);
        }

        [HttpGet("token")]
        public IActionResult GetMyPermanentJwt()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var userId = Guid.Parse(sub);

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
