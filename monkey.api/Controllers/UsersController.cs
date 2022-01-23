using Microsoft.AspNetCore.Mvc;
using monkey.api.Models;
using monkey.api.Services;
namespace monkey.api.Controllers;

[ApiController]
[Route("[controller]")]

public class AppUsersController : ControllerBase
{
    private readonly ILogger<AppUser> _logger;
    private readonly AppUserService _appUserService;
    public AppUsersController(ILogger<AppUser> logger, AppUserService appUserService)
    {
        _logger = logger;
        _appUserService = appUserService;
    }

    [HttpGet(Name = "GetAppUsers")]
    public IEnumerable<AppUser> Get()
    {
        return _appUserService.GetAppUsers(); 
    }
}
