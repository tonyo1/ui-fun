using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Services;
using monkey.api.Repsoitories;
namespace monkey.api.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
//using Cosmos.ModelBuilding;
using Microsoft.Azure.Cosmos;
//using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;



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
        /*
               using (var context = new CosmosBase(new DbContextOptions<CosmosBase>()))
                {

                  //   Delete a Cosmos database
                    Database database = context.Database.GetCosmosClient().GetDatabase("monkey-db");
                    DatabaseResponse response = database.DeleteAsync().Result;
               }
     
        var x = Task.Run(async () => await InsertUserAsync());
        x.Wait();

        var doc = Task.Run(() => FindDoc("KimberAshton"));
        doc.Wait();   */
        return _appUserService.GetAppUsers();
    }

    async Task<bool> InsertUserAsync()
    {
        try
        { 
            using (var context = new AppUsersStore(new DbContextOptions<CosmosBase>()))
            {
                await context.Database.EnsureCreatedAsync();
                for (int i = 5; i < 15; i++)
                {
                   context.AppUsers.Add(NewMethod(i));
                }
                
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.Message);
        }
        return true;

        static AppUser NewMethod(int i)
        {
            return new AppUser()
            {
                Id = i,
                UserName = $"{i} - KillingmeSmalls",
                Email = $"{i} - moemail.org",
                FirstName = $"{i} - Killing me",
                LastName = $"{i} - Smalls"
            };
        }
    }

    AppUser? FindDoc(string name)
    {
        using (var context = new AppUsersStore(new DbContextOptions<CosmosBase>()))
        {
            return context.AppUsers.Where(x => x.UserName.Contains(name)).FirstOrDefault();
        }
    }
}
