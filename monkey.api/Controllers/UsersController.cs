using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Services;
using monkey.api.Repsoitories;
namespace monkey.api.Controllers;
using System;
using System.Threading.Tasks;
//using Cosmos.ModelBuilding;
 

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
    
        return new List<AppUser>(){new AppUser()};
    }

    
 
}
