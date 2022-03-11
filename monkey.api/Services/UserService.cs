using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using monkey.api.Models;

namespace monkey.api.Services;
public interface IAppUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<AppUser> GetAll();
    AppUser GetById(int id);
}

public class AppUserService : IAppUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<AppUser> _users = new List<AppUser>
    {
        new AppUser { UserId = 1, FirstName = "Needs a f name", LastName = "User", UserName = "test", Email = "test" }
        ,new AppUser { UserId = 2, FirstName = "Test", LastName = "User", UserName = "string",  Email = "test"}

    };

    private readonly IConfiguration _appSettings;

    public AppUserService(IConfiguration appConfig)
    {
        _appSettings = appConfig;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.UserName == model.UserName && model.Password == model.Password);

        // return null if user not found
        if (user == null) return null;
        var authresp = new AuthenticateResponse(user);
        authresp.Roles.Add("admin");
        authresp.Roles.Add("nother");
        return authresp;
    }

    public IEnumerable<AppUser> GetAll()
    {
        return _users;
    }

    public AppUser? GetById(int userId)
    {
        return _users.FirstOrDefault(x => x.UserId == userId);
    }

    // helper methods
 
}