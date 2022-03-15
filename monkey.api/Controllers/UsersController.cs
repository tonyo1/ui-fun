using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Services;
using System;
using monkey.api.Helpers;
using Microsoft.AspNetCore.Cors;
namespace monkey.api.Controllers;

public class AppController : Controller
{

}
public class MonkeyControllerBase : ControllerBase
{

}
[EnableCors("MyPolicy")]
[ApiController]
[Route("[controller]")]
[Authorize]
public class AppUsersController : MonkeyControllerBase
{
    private readonly ILogger<AppUser> _logger;
    private readonly AppSettings _appSettings;
    private readonly IAppUserService _appUserService;

    //  private readonly AppUserService _appUserService;
    public AppUsersController(ILogger<AppUser> logger
        , AppSettings appSettings
        , IAppUserService appUserService)
    {
        _logger = logger;
        this._appSettings = appSettings;
        this._appUserService = appUserService;
        //_appUserService = new AppUserService(new MyContext(new DbContextOptions<MyContext>()), appSettings);
    }

    [HttpGet(Name = "GetAppUsers")]
    [Authorize]
    public IEnumerable<AppUser> Get()
    {

        return new List<AppUser>() { new AppUser() { UserId = 1 } };// _appUserService.GetAppUsers();
    }

    [HttpPut(Name = "SetAppput")]
     [Authorize]
    public AppUser Put()
    {
        var user = (AppUser)HttpContext.Items["User"];
        return user;//new List<AppUser>(){ new AppUser() { LastName = "That worked" }};// _appUserService.GetAppUsers();
    }

 
    [HttpDelete(Name = "SetApp22")]
    public AppUser foo([FromBody] List<string> inf)
    {
        var user = (AppUser)HttpContext.Items["User"];
        return user;//new List<AppUser>(){ new AppUser() { LastName = "That worked" }};// _appUserService.GetAppUsers();
    }
    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public object Login([FromBody] AuthenticateRequest info)
    {

        var response = _appUserService.Authenticate(info);

        return Ok(new
        {
            id_token = JwtMiddleware
                .GenerateJwtToken(response, _appSettings, out DateTime expires),
            expires_at = expires,
            appUser = (AppUser)response
        });



    }

}
