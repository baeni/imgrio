using imgrio_api.Entities;
using imgrio_api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imgrio_api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "SupabaseJwtPolicy")]
public class ContentsController : ControllerBase
{
    private readonly IDbRepository<UserContent> _dbUserContentsRepository;

    public ContentsController(IDbRepository<UserContent> dbUserContentsRepository)
    {
        _dbUserContentsRepository = dbUserContentsRepository;
    }
        
    [HttpGet("{id}"), AllowAnonymous]
    public async Task<IActionResult> GetUserContentAsync(Guid id)
    {
        var userContent = await _dbUserContentsRepository.GetSingle(id);
    
        if (userContent == null)
        {
            return NotFound("UserContent could not be found in database.");
        }
    
        return Ok(userContent);
    }
}