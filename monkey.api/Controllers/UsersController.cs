using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Services;
using monkey.api.Repsoitories;
namespace monkey.api.Controllers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using monkey.api.Helpers;

//using Cosmos.ModelBuilding;


[ApiController]
[Route("[controller]")]
[Authorize]
public class AppUsersController : ControllerBase
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

        return new List<AppUser>();// _appUserService.GetAppUsers();
    }

    [HttpPut(Name = "SetApp")]
    public IEnumerable<AppUser> Set()
    {

        return new List<AppUser>();// _appUserService.GetAppUsers();
    }


    [HttpPost(Name = "Login")]
    [AllowAnonymous]
    public object Login([FromBody] AuthenticateRequest info)
    { 

        var  response = _appUserService.Authenticate(info);
        //setTokenCookie(response);
       
         this.HttpContext.Items["User"] = (AppUser)response;
         
        return Ok(response);
      //  var user = Authenticate(info);
      //  return new { data = info };

    }

}
