using Microsoft.AspNetCore.Mvc;
using Placeholder.Domain.Abstractions;
using Placeholder.Domain.Models;

namespace Placeholder.Api.Controllers;

[ApiController]
[Route("/profiles")]
public class ProfilesController : ControllerBase
{
    private readonly IProfilesService _profilesService;
    public ProfilesController(IProfilesService profilesService)
    {
        _profilesService = profilesService;
    }
    [HttpGet]    
    public async Task<ActionResult> GetProfiles([FromHeader(Name = "X-API-Key")] string apiKey, int quantity)
    {
        var results = await _profilesService.GetRandomProfiles(quantity);
        return Ok(results);
    }
}