using HeyRed.Mime;
using imgrio_api.Extensions;
using imgrio_api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using imgrio_api.Infrastructure;
using imgrio_api.Dtos;

namespace imgrio_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "SupabaseJwtPolicy")]
    public class MeController : ControllerBase
    {
        private readonly IDbRepository<UserContent> _dbUserContentsRepository;
        private readonly IConfiguration _configuration;

        public MeController(IDbRepository<UserContent> dbUserContentsRepository, IConfiguration configuration)
        {
            _dbUserContentsRepository = dbUserContentsRepository;
            _configuration = configuration;
        }

        #region /me/files
        [HttpGet("files")]
        public async Task<IActionResult> GetUserContentsAsync()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var authorId = Guid.Parse(sub);

            var userContents = await _dbUserContentsRepository.GetAll(authorId);

            return Ok(userContents);
        }

        [HttpPost("files")]
        [Authorize(AuthenticationSchemes = "PermanentJwtPolicy")]
        public async Task<IActionResult> PostUserContentAsync([FromForm] IFormFile file)
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

            var authorId = Guid.Parse(sub);

            var id = Guid.NewGuid();
            var mimeType = file.ContentType;
            var userContent = new UserContent(
                id,
                authorId,
                Path.GetFileNameWithoutExtension(file.FileName),
                mimeType,
                file.Length,
                $"https://data.imgrio.com/{authorId}/{id}.{MimeTypesMap.GetExtension(mimeType)}",
                DateTime.UtcNow
            );

            #region save to imgrio server
            var path = $"./data/{userContent.AuthorId}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using var stream = new FileStream($"{path}/{userContent}", FileMode.Create);
            await file.CopyToAsync(stream);
            #endregion

            await _dbUserContentsRepository.Create(userContent);

            var responseDto = new PostUserContentResponseDto(
                userContent,
                url: $"https://imgrio.com/v/{id}");

            return Ok(responseDto);
        }

        [HttpDelete("files/{id}")]
        public async Task<IActionResult> DeleteUserContentAsync(Guid id)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var authorId = Guid.Parse(sub);

            var userContent = await _dbUserContentsRepository.GetSingle(id);
            if (userContent == null)
            {
                return NotFound("UserContent could not be found in database.");
            }
            if (userContent.AuthorId != authorId)
            {
                return Unauthorized("Sub and Author do not match.");
            }

            await _dbUserContentsRepository.Delete(userContent);

            #region delete from imgrio server
            var path = $"./data/{userContent.AuthorId}/{userContent}";
            if (!System.IO.File.Exists(path))
            {
                return NotFound("UserContent could not be found on imgrio server.");
            }
            System.IO.File.Delete(path);
            #endregion

            return Ok("Successfully deleted UserContent.");
        }
        #endregion

        [HttpGet("token")]
        public IActionResult GetPermanentJwt()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
            {
                return Unauthorized("Sub is invalid.");
            }

            var authorId = Guid.Parse(sub);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["PermanentJwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, authorId.ToString()),
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
